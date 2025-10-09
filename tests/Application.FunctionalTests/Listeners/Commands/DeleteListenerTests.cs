using CleanArchitecture.Application.Listeners.Commands.CreateListener;
using CleanArchitecture.Application.Listeners.Commands.DeleteListener;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions.ListenerExceptions;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CleanArchitecture.Application.FunctionalTests.Listeners.Commands;

using static Testing;

public class DeleteListenerTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidListenerId()
    {
        var command = new DeleteListenerCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ListenerNotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteListener()
    {
        var createCommand = new CreateListenerCommand
        {
            Name = "Listener To Delete",
            Username = "listenerdelete",
            Email = "listenerdelete@example.com",
            Password = "ListenerDelete123!"
        };

        var listenerId = await SendAsync(createCommand);

        await SendAsync(new DeleteListenerCommand(listenerId));

        var listener = await FindAsync<Listener>(listenerId);

        listener.Should().BeNull();
    }
}
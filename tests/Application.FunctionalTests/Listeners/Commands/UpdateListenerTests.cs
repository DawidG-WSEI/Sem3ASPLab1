using CleanArchitecture.Application.Listeners.Commands.CreateListener;
using CleanArchitecture.Application.Listeners.Commands.UpdateListener;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions.ListenerExceptions;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CleanArchitecture.Application.FunctionalTests.Listeners.Commands;

using static Testing;

public class UpdateListenerTests : BaseTestFixture
{
    [Test]
    public async Task ShouldThrowIfListenerNotFound()
    {
        var command = new UpdateListenerCommand
        {
            Id = 999,
            Name = "Updated Name"
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ListenerNotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateListenerName()
    {
        var listenerId = await SendAsync(new CreateListenerCommand
        {
            Name = "Original Name",
            Username = "updatelistener",
            Email = "updatelistener@example.com",
            Password = "ListenerTest123!"
        });

        var updateCommand = new UpdateListenerCommand
        {
            Id = listenerId,
            Name = "Updated Name"
        };

        await SendAsync(updateCommand);

        var listener = await FindAsync<Listener>(listenerId);

        listener.Should().NotBeNull();
        listener!.Name.Should().Be("Updated Name");
    }
}
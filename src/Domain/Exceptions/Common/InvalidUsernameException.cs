using System;

namespace CleanArchitectureProject.Domain.Exceptions.Common;

public class InvalidUsernameException : Exception
{
    public InvalidUsernameException(string username, string reason)
        : base($"Username '{username}' is invalid: {reason}")
    {
    }
}
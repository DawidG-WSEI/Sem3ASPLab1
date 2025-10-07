using System;

namespace CleanArchitectureProject.Domain.Exceptions.Common;

public class InsufficientPermissionsException : Exception
{
    public InsufficientPermissionsException(string message = "You do not have sufficient permissions to perform this action.")
        : base(message)
    {
    }
}
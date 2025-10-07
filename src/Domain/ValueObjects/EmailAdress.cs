using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Exceptions.ArtistExceptions;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.ValueObjects;

public sealed class EmailAddress : ValueObject
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEmailException(value);

        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new InvalidEmailException(value);

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;

    public static implicit operator string(EmailAddress email) => email.Value;
}
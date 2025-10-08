using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Exceptions.ArtistExceptions;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.ValueObjects;

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
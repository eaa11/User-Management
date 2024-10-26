﻿using UserManagement.API.Commom;

namespace UserManagement.API.Features.Users.Entities
{
    public record Token
    {
        public string Value { get; }

        public Token(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("Token cannot be null or empty.");
            }

            Value = value;
        }

        public static Token Generate()
        {
            return new Token(Guid.NewGuid().ToString());
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
namespace Raccoonlang.Tokenizer.Exceptions;

using System;

public class TokenMismatchException : Exception
{
    public TokenMismatchException(Token token, TokenType type)
    : base($"Expected `{type}` but got `{token.Type}` instead.") {}
}
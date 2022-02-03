namespace Raccoonlang.Tokenizing.Exceptions;

using System;

public class TokenMismatchException : Exception
{
    public TokenMismatchException(Token token, TokenType type)
    : base($"{token.FileName}:{token.Line}:{token.Column} | Expected `{type}` but got `{token.Type}` instead.") {}
}
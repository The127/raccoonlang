namespace Raccoonlang.Tokenizing.Exceptions;

using System;

public class TokenNotRecognizedException : Exception
{
    public TokenNotRecognizedException(string filePath, int line, int column, string fileContent) 
    : base($"{filePath}:{line}:{column} | Unknown token found near {fileContent}!") {}
}
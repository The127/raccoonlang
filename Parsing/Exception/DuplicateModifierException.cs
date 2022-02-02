namespace Raccoonlang.Parsing.Exception;

using Tokenizing;

public class DuplicateModifierException : System.Exception
{
    public DuplicateModifierException(Token t) : base($"Duplicate modifier at: {t}") {}
}
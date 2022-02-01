namespace Raccoonlang.Parser.Exception;

using Tokenizer;

public class DuplicateModifierException : System.Exception
{
    public DuplicateModifierException(Token t) : base($"Duplicate modifier at: {t}") {}
}
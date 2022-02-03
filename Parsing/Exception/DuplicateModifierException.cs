namespace Raccoonlang.Parsing.Exception;

using Tokenizing;

public class DuplicateModifierException : System.Exception
{
    public DuplicateModifierException(Token t) : base($"{t.FileName}:{t.Line}:{t.Column} | Duplicate modifier at: {t}") {}
}
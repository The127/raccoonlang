namespace Raccoonlang.Tokenizer;

public interface ITokenMatcher
{
    Token match(string currentString, int line, int column, String fileName);
}
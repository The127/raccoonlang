namespace Raccoonlang.Tokenizer;

public interface ITokenMatcher
{
    Token Match(string currentString, int line, int column, String fileName);
}
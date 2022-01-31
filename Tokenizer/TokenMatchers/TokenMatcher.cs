namespace Raccoonlang.Tokenizer.TokenMatchers;

using Raccoonlang.Tokenizer;
public abstract class TokenMatcher : ITokenMatcher
{
    public string CheckValue {get;private set;}
    private TokenType type;

    public TokenMatcher(string checkValue, TokenType tokenType)
    {
        this.CheckValue = checkValue;
        this.type = tokenType;
    }

    public Token match(string currentText, int line, int column, string fileName)
    {
        if (currentText.StartsWith(this.CheckValue)) {
            return new Token(this.type, line, column, CheckValue, fileName);
        }
        return null;
    }
}
namespace Raccoonlang.Tokenizer.TokenMatchers;

using System.Text.RegularExpressions;

public abstract class RegexTokenMatcher : ITokenMatcher
{
    private Regex pattern;
    public TokenType Type {get; private set;}
    public bool Skip {get; private set;}

    public RegexTokenMatcher(string regex, TokenType token, bool skip)
    {
        this.pattern = new Regex("^"+regex);
        this.Type = token;
        this.Skip = skip; 
    }

    public RegexTokenMatcher(string regex, TokenType token)
    {
        this.pattern = new Regex("^"+regex);
        this.Type = token;
        this.Skip = false;
    }

    public Token Match(string currentText, int line, int column, string fileName)
    {
        MatchCollection coll = pattern.Matches(currentText);
        if (coll.Count > 0) {
            return new Token(this.Type, line, column, coll[0].ToString(), fileName, this.Skip);
        }
        return null;
    }
}
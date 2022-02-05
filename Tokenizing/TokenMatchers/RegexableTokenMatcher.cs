namespace Raccoonlang.Tokenizing.TokenMatchers;

using System.Text.RegularExpressions;

public abstract class RegexableTokenMatcher : ITokenMatcher
{
    private Regex _pattern;
    public TokenType Type {get; private set;}
    public bool Skip {get; private set;}

    public RegexableTokenMatcher(string regex, TokenType token, bool skip)
    {
        this._pattern = new Regex("^"+regex);
        this.Type = token;
        this.Skip = skip; 
    }

    public RegexableTokenMatcher(string regex, TokenType token)
    {
        this._pattern = new Regex("^"+regex);
        this.Type = token;
        this.Skip = false;
    }

    public Token? Match(string currentText, int line, int column, string fileName)
    {
        MatchCollection coll = _pattern.Matches(currentText);
        if (coll.Count > 0) {
            return new Token(this.Type, line, column, coll[0].ToString(), fileName, this.Skip);
        }
        return null;
    }
}
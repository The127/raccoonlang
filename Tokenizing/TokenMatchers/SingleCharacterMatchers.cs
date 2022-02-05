namespace Raccoonlang.Tokenizing.TokenMatchers;

public class DotTokenMatcher : TokenMatcher
{
    public DotTokenMatcher() : base(".", TokenType.Dot) {}
}

public class SemicolonTokenMatcher : TokenMatcher
{
    public SemicolonTokenMatcher() : base(";", TokenType.Semicolon) {}
}

public class ColonTokenMatcher : TokenMatcher
{
    public ColonTokenMatcher() : base(":", TokenType.Colon) {}
}

public class EqualsTokenMatcher : TokenMatcher
{
    public EqualsTokenMatcher() : base("=", TokenType.Equals) {}
}

public class CommaTokenMatcher : TokenMatcher
{
    public CommaTokenMatcher() : base(",", TokenType.Comma) {}
}

public class CloseCurlyTokenMatcher : TokenMatcher
{
    public CloseCurlyTokenMatcher() : base("}", TokenType.CloseCurly) {}
}

public class CloseParenTokenMatcher : TokenMatcher
{
    public CloseParenTokenMatcher() : base(")", TokenType.CloseParen) {}
}

public class CloseSquareTokenMatcher : TokenMatcher
{
    public CloseSquareTokenMatcher() : base("]", TokenType.CloseSquare) {}
}

public class OpenCurlyTokenMatcher : TokenMatcher
{
    public OpenCurlyTokenMatcher() : base("{", TokenType.OpenCurly) {}
}

public class OpenParenTokenMatcher : TokenMatcher
{
    public OpenParenTokenMatcher() : base("(", TokenType.OpenParen) {}
}

public class OpenSquareTokenMatcher : TokenMatcher
{
    public OpenSquareTokenMatcher() : base("[", TokenType.OpenSquare) {}
}
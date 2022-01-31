namespace Raccoonlang.Tokenizer.TokenMatchers;

public class DotTokenMatcher : TokenMatcher
{
    public DotTokenMatcher() : base(".", TokenType.DOT) {}
}

public class SemicolonTokenMatcher : TokenMatcher
{
    public SemicolonTokenMatcher() : base(";", TokenType.SEMICOLON) {}
}

public class ColonTokenMatcher : TokenMatcher
{
    public ColonTokenMatcher() : base(":", TokenType.COLON) {}
}

public class EqualsTokenMatcher : TokenMatcher
{
    public EqualsTokenMatcher() : base("=", TokenType.EQUALS) {}
}

public class CommaTokenMatcher : TokenMatcher
{
    public CommaTokenMatcher() : base(",", TokenType.COMMA) {}
}

public class CloseCurlyTokenMatcher : TokenMatcher
{
    public CloseCurlyTokenMatcher() : base("}", TokenType.CLOSE_CURLY) {}
}

public class CloseParenTokenMatcher : TokenMatcher
{
    public CloseParenTokenMatcher() : base(")", TokenType.CLOSE_PAREN) {}
}

public class CloseSquareTokenMatcher : TokenMatcher
{
    public CloseSquareTokenMatcher() : base("]", TokenType.CLOSE_SQUARE) {}
}

public class OpenCurlyTokenMatcher : TokenMatcher
{
    public OpenCurlyTokenMatcher() : base("{", TokenType.OPEN_CURLY) {}
}

public class OpenParenTokenMatcher : TokenMatcher
{
    public OpenParenTokenMatcher() : base("(", TokenType.OPEN_PAREN) {}
}

public class OpenSquareTokenMatcher : TokenMatcher
{
    public OpenSquareTokenMatcher() : base("[", TokenType.OPEN_SQUARE) {}
}
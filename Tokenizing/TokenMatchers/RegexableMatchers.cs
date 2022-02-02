namespace Raccoonlang.Tokenizing.TokenMatchers;

public class StringLiteralTokenMatcher : RegexableTokenMatcher
{
    public StringLiteralTokenMatcher() : base(@"""(.|\n|\r)*""", TokenType.STRING_LITERAL) {}
}

public class NumberLiteralTokenMatcher : RegexableTokenMatcher
{
    public NumberLiteralTokenMatcher() : base(@"(((\d[\d_]*)?\.(\d[\d_]*))|((\d[\d_]*)\.(\d[\d_]*)?)|(\d[\d_]*))(([ui](8|16|32|64))|f(32|64))?", TokenType.NUMBER_LITERAL) {}
}

public class WhiteSpaceTokenMatcher : RegexableTokenMatcher
{
    public WhiteSpaceTokenMatcher() : base(@"\s", TokenType.WHITE_SPACE) {}
}

public class IdentifierTokenMatcher : RegexableTokenMatcher
{
    public IdentifierTokenMatcher() : base(@"[_a-zA-Z][_a-zA-Z0123456789]*", TokenType.IDENTIFIER) {}
}

public class MultiLineCommentTokenMatcher : RegexableTokenMatcher
{
    public MultiLineCommentTokenMatcher() : base(@"/\*.*\*/", TokenType.MULTI_LINE_COMMENT) {}
}

public class CommentTokenMatcher : RegexableTokenMatcher
{
    public CommentTokenMatcher() : base("(//.*)\n", TokenType.COMMENT) {}
}
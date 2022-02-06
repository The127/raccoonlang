namespace Raccoonlang.Tokenizing.TokenMatchers;

public class StringLiteralTokenMatcher : RegexableTokenMatcher
{
    public StringLiteralTokenMatcher() : base(@"""(.|\n|\r)*""", TokenType.StringLiteral) {}
}

public class NumberLiteralTokenMatcher : RegexableTokenMatcher
{
    public NumberLiteralTokenMatcher() : base(@"(((\d[\d_]*)?\.(\d[\d_]*))|((\d[\d_]*)\.(\d[\d_]*)?)|(\d[\d_]*))(([ui](8|16|32|64))|f(32|64))?", TokenType.NumberLiteral) {}
}

public class WhiteSpaceTokenMatcher : RegexableTokenMatcher
{
    public WhiteSpaceTokenMatcher() : base(@"\s", TokenType.WhiteSpace, true) {}
}

public class IdentifierTokenMatcher : RegexableTokenMatcher
{
    public IdentifierTokenMatcher() : base(@"[_a-zA-Z][_a-zA-Z0123456789]*", TokenType.Identifier) {}
}

public class MultiLineCommentTokenMatcher : RegexableTokenMatcher
{
    public MultiLineCommentTokenMatcher() : base(@"/\*.*\*/", TokenType.MultiLineComment, true) {}
}

public class CommentTokenMatcher : RegexableTokenMatcher
{
    public CommentTokenMatcher() : base(@"(//.*)\n", TokenType.Comment, true) {}
}
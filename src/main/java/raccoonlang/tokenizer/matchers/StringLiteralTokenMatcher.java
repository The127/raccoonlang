package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class StringLiteralTokenMatcher extends RegexTokenMatcherBase {
    public StringLiteralTokenMatcher() {
        super("\"(\\.|[^\"\\\\])*\"", TokenType.STRING_LITERAL);
    }
}

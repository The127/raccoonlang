package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpenParenthesisTokenMatcher extends EqualsTokenMatcherBase {
    public OpenParenthesisTokenMatcher() {
        super("(", TokenType.OPEN_PAREN);
    }
}

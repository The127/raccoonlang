package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class CloseParenthesisTokenMatcher extends EqualsTokenMatcherBase {
    public CloseParenthesisTokenMatcher() {
        super(")", TokenType.CLOSE_PAREN);
    }
}

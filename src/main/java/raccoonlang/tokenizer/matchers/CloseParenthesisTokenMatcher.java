package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class CloseParenthesisTokenMatcher extends ConstantTokenMatcherBase {
    public CloseParenthesisTokenMatcher() {
        super(")", TokenType.CLOSE_PAREN);
    }
}

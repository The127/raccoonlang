package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpenParenthesisTokenMatcher extends ConstantTokenMatcherBase {
    public OpenParenthesisTokenMatcher() {
        super("(", TokenType.OPEN_PAREN);
    }
}

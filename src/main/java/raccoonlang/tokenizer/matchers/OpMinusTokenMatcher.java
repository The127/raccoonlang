
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpMinusTokenMatcher extends ConstantTokenMatcherBase {
    public OpMinusTokenMatcher() {
        super("-", TokenType.OP_MINUS);
    }
}

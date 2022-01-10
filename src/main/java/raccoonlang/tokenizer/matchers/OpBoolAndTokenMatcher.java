
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpBoolAndTokenMatcher extends ConstantTokenMatcherBase {
    public OpBoolAndTokenMatcher() {
        super("&&", TokenType.OP_BOOL_AND);
    }
}

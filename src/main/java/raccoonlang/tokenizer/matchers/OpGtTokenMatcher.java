
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpGtTokenMatcher extends ConstantTokenMatcherBase {
    public OpGtTokenMatcher() {
        super(">", TokenType.OP_GT);
    }
}

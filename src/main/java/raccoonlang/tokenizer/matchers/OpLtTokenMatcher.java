
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpLtTokenMatcher extends ConstantTokenMatcherBase {
    public OpLtTokenMatcher() {
        super("<", TokenType.OP_LT);
    }
}

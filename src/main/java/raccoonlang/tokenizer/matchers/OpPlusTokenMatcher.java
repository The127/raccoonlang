
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpPlusTokenMatcher extends ConstantTokenMatcherBase {
    public OpPlusTokenMatcher() {
        super("+", TokenType.OP_PLUS);
    }
}

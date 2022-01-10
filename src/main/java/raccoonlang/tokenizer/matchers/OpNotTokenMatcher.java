
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpNotTokenMatcher extends ConstantTokenMatcherBase {
    public OpNotTokenMatcher() {
        super("!", TokenType.OP_NOT);
    }
}


package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpTimesTokenMatcher extends ConstantTokenMatcherBase {
    public OpTimesTokenMatcher() {
        super("*", TokenType.OP_TIMES);
    }
}

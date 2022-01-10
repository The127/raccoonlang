
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpXorTokenMatcher extends ConstantTokenMatcherBase {
    public OpXorTokenMatcher() {
        super("^", TokenType.OP_XOR);
    }
}

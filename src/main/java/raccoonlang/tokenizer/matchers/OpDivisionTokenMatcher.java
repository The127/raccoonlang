
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpDivisionTokenMatcher extends ConstantTokenMatcherBase {
    public OpDivisionTokenMatcher() {
        super("/", TokenType.OP_DIVISION);
    }
}

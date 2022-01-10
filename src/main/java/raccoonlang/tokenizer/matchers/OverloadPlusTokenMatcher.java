
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OverloadPlusTokenMatcher extends ConstantTokenMatcherBase {
    public OverloadPlusTokenMatcher() {
        super("operator+", TokenType.OVERLOAD_PLUS);
    }
}

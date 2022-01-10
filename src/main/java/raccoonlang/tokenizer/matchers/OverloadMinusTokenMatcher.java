
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OverloadMinusTokenMatcher extends ConstantTokenMatcherBase {
    public OverloadMinusTokenMatcher() {
        super("operator-", TokenType.OVERLOAD_MINUS);
    }
}

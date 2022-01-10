
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OverloadDivisionTokenMatcher extends ConstantTokenMatcherBase {
    public OverloadDivisionTokenMatcher() {
        super("operator/", TokenType.OVERLOAD_DIVISION);
    }
}

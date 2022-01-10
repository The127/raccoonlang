
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class AndEqualsTokenMatcher extends ConstantTokenMatcherBase {
    public AndEqualsTokenMatcher() {
        super("&=", TokenType.AND_EQUALS);
    }
}

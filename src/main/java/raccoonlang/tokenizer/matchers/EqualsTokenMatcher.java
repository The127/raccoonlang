
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class EqualsTokenMatcher extends ConstantTokenMatcherBase {
    public EqualsTokenMatcher() {
        super("=", TokenType.EQUALS);
    }
}

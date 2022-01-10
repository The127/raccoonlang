
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class PlusEqualsTokenMatcher extends ConstantTokenMatcherBase {
    public PlusEqualsTokenMatcher() {
        super("+=", TokenType.PLUS_EQUALS);
    }
}

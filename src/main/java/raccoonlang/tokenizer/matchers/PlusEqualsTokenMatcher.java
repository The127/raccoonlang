
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class PlusEqualsTokenMatcher extends EqualsTokenMatcherBase {
    public PlusEqualsTokenMatcher() {
        super("+=", TokenType.PLUS_EQUALS);
    }
}

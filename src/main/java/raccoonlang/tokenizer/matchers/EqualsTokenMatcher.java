
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class EqualsTokenMatcher extends EqualsTokenMatcherBase {
    public EqualsTokenMatcher() {
        super("=", TokenType.EQUALS);
    }
}


package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class AndEqualsTokenMatcher extends EqualsTokenMatcherBase {
    public AndEqualsTokenMatcher() {
        super("&=", TokenType.AND_EQUALS);
    }
}


package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OrEqualsTokenMatcher extends EqualsTokenMatcherBase {
    public OrEqualsTokenMatcher() {
        super("|=", TokenType.OR_EQUALS);
    }
}


package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class DivisionEqualsTokenMatcher extends EqualsTokenMatcherBase {
    public DivisionEqualsTokenMatcher() {
        super("/=", TokenType.DIVISION_EQUALS);
    }
}

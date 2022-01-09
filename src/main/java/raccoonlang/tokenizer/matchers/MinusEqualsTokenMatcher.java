
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class MinusEqualsTokenMatcher extends EqualsTokenMatcherBase {
    public MinusEqualsTokenMatcher() {
        super("-=", TokenType.MINUS_EQUALS);
    }
}

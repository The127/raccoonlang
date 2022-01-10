
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class MinusEqualsTokenMatcher extends ConstantTokenMatcherBase {
    public MinusEqualsTokenMatcher() {
        super("-=", TokenType.MINUS_EQUALS);
    }
}

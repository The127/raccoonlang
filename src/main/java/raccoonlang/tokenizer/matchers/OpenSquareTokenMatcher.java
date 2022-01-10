
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpenSquareTokenMatcher extends ConstantTokenMatcherBase {
    public OpenSquareTokenMatcher() {
        super("[", TokenType.OPEN_SQUARE);
    }
}

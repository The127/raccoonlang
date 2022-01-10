
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class CloseSquareTokenMatcher extends ConstantTokenMatcherBase {
    public CloseSquareTokenMatcher() {
        super("]", TokenType.CLOSE_SQUARE);
    }
}

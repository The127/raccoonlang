
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class CloseCurlyTokenMatcher extends ConstantTokenMatcherBase {
    public CloseCurlyTokenMatcher() {
        super("}", TokenType.CLOSE_CURLY);
    }
}

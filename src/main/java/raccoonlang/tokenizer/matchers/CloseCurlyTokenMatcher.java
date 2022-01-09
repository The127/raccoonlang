
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class CloseCurlyTokenMatcher extends EqualsTokenMatcherBase {
    public CloseCurlyTokenMatcher() {
        super("}", TokenType.CLOSE_CURLY);
    }
}

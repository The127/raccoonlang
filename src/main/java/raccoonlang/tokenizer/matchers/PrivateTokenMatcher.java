
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class PrivateTokenMatcher extends EqualsTokenMatcherBase {
    public PrivateTokenMatcher() {
        super("private", TokenType.PRIVATE);
    }
}

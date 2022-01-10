
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class PrivateTokenMatcher extends ConstantTokenMatcherBase {
    public PrivateTokenMatcher() {
        super("private", TokenType.PRIVATE);
    }
}


package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ProtectedTokenMatcher extends ConstantTokenMatcherBase {
    public ProtectedTokenMatcher() {
        super("protected", TokenType.PROTECTED);
    }
}


package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ProtectedTokenMatcher extends EqualsTokenMatcherBase {
    public ProtectedTokenMatcher() {
        super("protected", TokenType.PROTECTED);
    }
}

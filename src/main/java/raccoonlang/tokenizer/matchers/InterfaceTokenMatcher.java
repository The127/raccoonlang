
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class InterfaceTokenMatcher extends ConstantTokenMatcherBase {
    public InterfaceTokenMatcher() {
        super("interface", TokenType.INTERFACE);
    }
}

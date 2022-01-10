
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class XorEqualsTokenMatcher extends ConstantTokenMatcherBase {
    public XorEqualsTokenMatcher() {
        super("^=", TokenType.XOR_EQUALS);
    }
}

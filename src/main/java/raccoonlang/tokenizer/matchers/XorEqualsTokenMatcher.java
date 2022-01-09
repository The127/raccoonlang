
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class XorEqualsTokenMatcher extends EqualsTokenMatcherBase {
    public XorEqualsTokenMatcher() {
        super("^=", TokenType.XOR_EQUALS);
    }
}

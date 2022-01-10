
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class U16TokenMatcher extends ConstantTokenMatcherBase {
    public U16TokenMatcher() {
        super("u16", TokenType.U16);
    }
}

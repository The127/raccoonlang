
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class U8TokenMatcher extends ConstantTokenMatcherBase {
    public U8TokenMatcher() {
        super("u8", TokenType.U8);
    }
}

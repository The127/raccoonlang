
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class TrueTokenMatcher extends ConstantTokenMatcherBase {
    public TrueTokenMatcher() {
        super("true", TokenType.TRUE);
    }
}

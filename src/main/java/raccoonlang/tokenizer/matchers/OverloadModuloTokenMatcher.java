
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OverloadModuloTokenMatcher extends ConstantTokenMatcherBase {
    public OverloadModuloTokenMatcher() {
        super("operator%", TokenType.OVERLOAD_MODULO);
    }
}

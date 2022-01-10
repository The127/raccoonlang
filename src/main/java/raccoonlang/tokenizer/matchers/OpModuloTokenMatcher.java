
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpModuloTokenMatcher extends ConstantTokenMatcherBase {
    public OpModuloTokenMatcher() {
        super("%", TokenType.OP_MODULO);
    }
}

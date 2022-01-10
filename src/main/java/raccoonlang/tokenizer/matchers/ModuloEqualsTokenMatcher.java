
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ModuloEqualsTokenMatcher extends ConstantTokenMatcherBase {
    public ModuloEqualsTokenMatcher() {
        super("%=", TokenType.MODULO_EQUALS);
    }
}

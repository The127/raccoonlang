
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ModuloEqualsTokenMatcher extends EqualsTokenMatcherBase {
    public ModuloEqualsTokenMatcher() {
        super("%=", TokenType.MODULO_EQUALS);
    }
}

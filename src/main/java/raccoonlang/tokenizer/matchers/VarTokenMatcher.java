
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class VarTokenMatcher extends ConstantTokenMatcherBase {
    public VarTokenMatcher() {
        super("var", TokenType.VAR);
    }
}

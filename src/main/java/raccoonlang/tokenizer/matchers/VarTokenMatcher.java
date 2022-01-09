
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class VarTokenMatcher extends EqualsTokenMatcherBase {
    public VarTokenMatcher() {
        super("var", TokenType.VAR);
    }
}

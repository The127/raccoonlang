
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class SemicolonTokenMatcher extends ConstantTokenMatcherBase {
    public SemicolonTokenMatcher() {
        super(";", TokenType.SEMICOLON);
    }
}

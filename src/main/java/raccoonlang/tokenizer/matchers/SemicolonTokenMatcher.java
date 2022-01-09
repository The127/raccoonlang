
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class SemicolonTokenMatcher extends EqualsTokenMatcherBase {
    public SemicolonTokenMatcher() {
        super(";", TokenType.SEMICOLON);
    }
}

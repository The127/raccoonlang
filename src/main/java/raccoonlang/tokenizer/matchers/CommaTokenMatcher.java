
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class CommaTokenMatcher extends EqualsTokenMatcherBase {
    public CommaTokenMatcher() {
        super(",", TokenType.COMMA);
    }
}

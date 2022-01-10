
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class CommaTokenMatcher extends ConstantTokenMatcherBase {
    public CommaTokenMatcher() {
        super(",", TokenType.COMMA);
    }
}

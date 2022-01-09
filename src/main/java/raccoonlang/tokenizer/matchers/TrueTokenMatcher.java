
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class TrueTokenMatcher extends EqualsTokenMatcherBase {
    public TrueTokenMatcher() {
        super("true", TokenType.TRUE);
    }
}

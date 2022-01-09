
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class FalseTokenMatcher extends EqualsTokenMatcherBase {
    public FalseTokenMatcher() {
        super("false", TokenType.FALSE);
    }
}

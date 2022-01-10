
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class FalseTokenMatcher extends ConstantTokenMatcherBase {
    public FalseTokenMatcher() {
        super("false", TokenType.FALSE);
    }
}

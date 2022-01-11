
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class FnTokenMatcher extends ConstantTokenMatcherBase {
    public FnTokenMatcher() {
        super("fn", TokenType.FN);
    }
}

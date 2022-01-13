
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class WhereTokenMatcher extends ConstantTokenMatcherBase {
    public WhereTokenMatcher() {
        super("where", TokenType.WHERE);
    }
}

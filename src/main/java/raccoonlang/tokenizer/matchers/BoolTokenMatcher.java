
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class BoolTokenMatcher extends ConstantTokenMatcherBase {
    public BoolTokenMatcher() {
        super("bool", TokenType.BOOL);
    }
}

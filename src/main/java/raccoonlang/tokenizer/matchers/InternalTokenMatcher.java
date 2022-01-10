
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class InternalTokenMatcher extends ConstantTokenMatcherBase {
    public InternalTokenMatcher() {
        super("internal", TokenType.INTERNAL);
    }
}

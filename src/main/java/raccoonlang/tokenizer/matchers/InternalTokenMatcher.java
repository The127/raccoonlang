
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class InternalTokenMatcher extends EqualsTokenMatcherBase {
    public InternalTokenMatcher() {
        super("internal", TokenType.INTERNAL);
    }
}

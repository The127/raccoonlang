
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class BoolTokenMatcher extends EqualsTokenMatcherBase {
    public BoolTokenMatcher() {
        super("bool", TokenType.BOOL);
    }
}

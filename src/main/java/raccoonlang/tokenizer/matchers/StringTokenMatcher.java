
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class StringTokenMatcher extends EqualsTokenMatcherBase {
    public StringTokenMatcher() {
        super("string", TokenType.STRING);
    }
}

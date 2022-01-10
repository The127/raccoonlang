
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class StringTokenMatcher extends ConstantTokenMatcherBase {
    public StringTokenMatcher() {
        super("string", TokenType.STRING);
    }
}

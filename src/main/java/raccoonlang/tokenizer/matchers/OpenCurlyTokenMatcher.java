
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpenCurlyTokenMatcher extends EqualsTokenMatcherBase {
    public OpenCurlyTokenMatcher() {
        super("{", TokenType.OPEN_CURLY);
    }
}

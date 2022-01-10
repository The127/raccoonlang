
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpenCurlyTokenMatcher extends ConstantTokenMatcherBase {
    public OpenCurlyTokenMatcher() {
        super("{", TokenType.OPEN_CURLY);
    }
}

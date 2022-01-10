
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class I32TokenMatcher extends ConstantTokenMatcherBase {
    public I32TokenMatcher() {
        super("i32", TokenType.I32);
    }
}

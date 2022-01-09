
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class I32TokenMatcher extends EqualsTokenMatcherBase {
    public I32TokenMatcher() {
        super("i32", TokenType.I32);
    }
}

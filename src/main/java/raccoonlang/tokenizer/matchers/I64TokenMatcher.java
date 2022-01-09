
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class I64TokenMatcher extends EqualsTokenMatcherBase {
    public I64TokenMatcher() {
        super("i64", TokenType.I64);
    }
}

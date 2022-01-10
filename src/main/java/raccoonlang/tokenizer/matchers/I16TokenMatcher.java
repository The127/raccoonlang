
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class I16TokenMatcher extends ConstantTokenMatcherBase {
    public I16TokenMatcher() {
        super("i16", TokenType.I16);
    }
}

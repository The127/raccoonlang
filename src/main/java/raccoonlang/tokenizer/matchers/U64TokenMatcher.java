
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class U64TokenMatcher extends ConstantTokenMatcherBase {
    public U64TokenMatcher() {
        super("u64", TokenType.U64);
    }}
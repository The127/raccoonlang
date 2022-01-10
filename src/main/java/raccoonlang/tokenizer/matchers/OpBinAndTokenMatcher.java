
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpBinAndTokenMatcher extends ConstantTokenMatcherBase {
    public OpBinAndTokenMatcher() {
        super("&", TokenType.OP_BIN_AND);
    }
}

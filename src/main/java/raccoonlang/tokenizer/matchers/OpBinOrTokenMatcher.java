
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpBinOrTokenMatcher extends ConstantTokenMatcherBase {
    public OpBinOrTokenMatcher() {
        super("|", TokenType.OP_BIN_OR);
    }
}

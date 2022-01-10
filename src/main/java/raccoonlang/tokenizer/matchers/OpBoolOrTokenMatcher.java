
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OpBoolOrTokenMatcher extends ConstantTokenMatcherBase {
    public OpBoolOrTokenMatcher() {
        super("||", TokenType.OP_BOOL_OR);
    }
}

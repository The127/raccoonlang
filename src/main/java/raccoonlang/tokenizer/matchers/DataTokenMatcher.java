
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class DataTokenMatcher extends ConstantTokenMatcherBase {
    public DataTokenMatcher() {
        super("data", TokenType.DATA);
    }
}

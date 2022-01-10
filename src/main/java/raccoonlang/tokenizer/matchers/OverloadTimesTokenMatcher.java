
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OverloadTimesTokenMatcher extends ConstantTokenMatcherBase {
    public OverloadTimesTokenMatcher() {
        super("operator*", TokenType.OVERLOAD_TIMES);
    }
}

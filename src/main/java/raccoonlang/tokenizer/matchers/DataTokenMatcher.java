
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class DataTokenMatcher extends EqualsTokenMatcherBase {
    public DataTokenMatcher() {
        super("data", TokenType.DATA);
    }
}

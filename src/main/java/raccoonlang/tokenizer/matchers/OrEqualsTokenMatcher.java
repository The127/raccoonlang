
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class OrEqualsTokenMatcher extends ConstantTokenMatcherBase {
    public OrEqualsTokenMatcher() {
        super("|=", TokenType.OR_EQUALS);
    }
}

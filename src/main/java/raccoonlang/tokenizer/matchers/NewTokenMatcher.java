
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class NewTokenMatcher extends ConstantTokenMatcherBase {
    public NewTokenMatcher() {
        super("new", TokenType.NEW);
    }
}

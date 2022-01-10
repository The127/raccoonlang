
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ClassTokenMatcher extends ConstantTokenMatcherBase {
    public ClassTokenMatcher() {
        super("class", TokenType.CLASS);
    }
}

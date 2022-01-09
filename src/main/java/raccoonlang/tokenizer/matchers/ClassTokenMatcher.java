
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ClassTokenMatcher extends EqualsTokenMatcherBase {
    public ClassTokenMatcher() {
        super("class", TokenType.CLASS);
    }
}


package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class PublicTokenMatcher extends EqualsTokenMatcherBase {
    public PublicTokenMatcher() {
        super("public", TokenType.PUBLIC);
    }
}

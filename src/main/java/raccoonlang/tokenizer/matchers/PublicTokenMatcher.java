
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class PublicTokenMatcher extends ConstantTokenMatcherBase {
    public PublicTokenMatcher() {
        super("public", TokenType.PUBLIC);
    }
}

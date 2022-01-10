
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ColonTokenMatcher extends ConstantTokenMatcherBase {
    public ColonTokenMatcher() {
        super(":", TokenType.COLON);
    }
}

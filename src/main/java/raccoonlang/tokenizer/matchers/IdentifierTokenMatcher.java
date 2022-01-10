package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class IdentifierTokenMatcher extends RegexTokenMatcherBase {
    public IdentifierTokenMatcher() {
        super("[_a-zA-Z][_a-zA-Z0123456789]*", TokenType.IDENTIFIER);
    }
}

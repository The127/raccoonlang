package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class NumberLiteralTokenMatcher extends RegexTokenMatcherBase {
    public NumberLiteralTokenMatcher() {
        super("(((\\d[\\d_]*)?\\.(\\d[\\d_]*))|((\\d[\\d_]*)\\.(\\d[\\d_]*)?)|(\\d[\\d_]*))(([ui](8|16|32|64))|f(32|64))?", TokenType.IDENTIFIER);
    }
}

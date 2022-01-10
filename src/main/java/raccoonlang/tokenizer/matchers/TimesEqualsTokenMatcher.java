
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class TimesEqualsTokenMatcher extends ConstantTokenMatcherBase {
    public TimesEqualsTokenMatcher() {
        super("*=", TokenType.TIMES_EQUALS);
    }
}

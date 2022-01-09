
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class LambdaArrowTokenMatcher extends EqualsTokenMatcherBase {
    public LambdaArrowTokenMatcher() {
        super("=>", TokenType.LAMBDA_ARROW);
    }
}

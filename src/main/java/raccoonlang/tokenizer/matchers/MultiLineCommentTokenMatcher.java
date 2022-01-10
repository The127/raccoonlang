package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class MultiLineCommentTokenMatcher extends RegexTokenMatcherBase {
    public MultiLineCommentTokenMatcher() {
        super("/\\*.*\\*/", TokenType.MULTI_LINE_COMMENT);
    }
}

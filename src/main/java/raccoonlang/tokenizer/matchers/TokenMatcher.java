package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.Token;

public interface TokenMatcher {
    Token match(String currentText, int line, int column, String fileName);
}

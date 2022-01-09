package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public abstract class EqualsTokenMatcherBase implements TokenMatcher {
    private String checkValue;
    private TokenType tokenType;

    public EqualsTokenMatcherBase(String checkValue, TokenType tokenType) {
        this.checkValue = checkValue;
        this.tokenType = tokenType;
    }

    @Override
    public Token match(String currentText, int line, int column, String fileName) {
        if(currentText.equals(checkValue)){
            return new Token(tokenType, line, column, currentText, fileName);
        }
        return null;
    }
}

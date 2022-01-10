package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public abstract class ConstantTokenMatcherBase implements TokenMatcher {
    private String checkValue;
    private TokenType tokenType;

    public ConstantTokenMatcherBase(String checkValue, TokenType tokenType) {
        this.checkValue = checkValue;
        this.tokenType = tokenType;
    }

    @Override
    public Token match(String currentText, int line, int column, String fileName) {
        if(currentText.startsWith(checkValue)){
            return new Token(tokenType, line, column, checkValue, fileName);
        }
        return null;
    }
}

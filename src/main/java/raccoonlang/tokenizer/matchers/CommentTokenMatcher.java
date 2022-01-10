package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

import java.util.regex.Pattern;

public class CommentTokenMatcher implements TokenMatcher {
    private Pattern pattern;

    public CommentTokenMatcher() {
        this.pattern = Pattern.compile("^(//.*)\n");
    }

    @Override
    public Token match(String currentText, int line, int column, String fileName) {
        var matcher = pattern.matcher(currentText);

        if(matcher.find()){
            return new Token(TokenType.COMMENT, line, column, matcher.group(0), fileName, true);
        }
        return null;
    }
}

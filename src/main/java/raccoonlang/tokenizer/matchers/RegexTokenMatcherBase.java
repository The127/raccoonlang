package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

import java.util.regex.Pattern;

public abstract class RegexTokenMatcherBase implements TokenMatcher {
    private Pattern pattern;
    private TokenType tokenType;
    private boolean skip;

    public RegexTokenMatcherBase(String regex, TokenType tokenType, boolean skip) {
        this.pattern = Pattern.compile("^" + regex);
        this.tokenType = tokenType;
        this.skip = skip;
    }

    public RegexTokenMatcherBase(String regex, TokenType tokenType) {
        this(regex, tokenType, false);
    }

    @Override
    public Token match(String currentText, int line, int column, String fileName) {
        var matcher = pattern.matcher(currentText);
        if(matcher.find()){
            return new Token(tokenType, line, column, matcher.group(), fileName, skip);
        }
        return null;
    }
}

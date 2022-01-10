package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class WhiteSpaceTokenMatcher implements TokenMatcher {
    @Override
    public Token match(String currentText, int line, int column, String fileName) {
        var match = false;
        var matchText = "";

        if(currentText.startsWith(" ")){
            match = true;
            matchText = " ";
        }else if(currentText.startsWith("\t")){
            match = true;
            matchText = "\t";
        }

        if(match){
            return new Token(TokenType.WHITE_SPACE, line, column, matchText, fileName, true);
        }else{
            return null;
        }
    }
}

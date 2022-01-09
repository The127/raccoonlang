package raccoonlang.tokenizer;

import java.util.ArrayList;
import java.util.List;

public class TokenStreamImpl implements TokenStream {

    int position = 0;
    private String filePath;
    private List<Token> tokenList;

    public TokenStreamImpl(String filePath, List<Token> tokenList) {
        this.filePath = filePath;
        this.tokenList = new ArrayList<>(tokenList);
    }


    @Override
    public Token take() {
        if(position >= tokenList.size()){
            Token eofToken = new Token(TokenType.EOF, -1, -1, "\0", filePath);
            return eofToken;
        }

        return tokenList.get(position++);
    }

    @Override
    public Token take(TokenType tokenType) {
        Token token = take();
        if(token.getTokenType() != tokenType){
            throw new TokenMismatchException(token, tokenType);
        }

        return token;
    }

    @Override
    public int size() {
        return tokenList.size();
    }
}

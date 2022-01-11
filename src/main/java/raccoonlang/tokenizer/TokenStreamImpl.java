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
            var eofLine = 0;
            var eofCol = 0;

            if(size() > 0){
                var lastToken = tokenList.get(tokenList.size()-1);
                eofLine = lastToken.getLine();
                eofCol = lastToken.getColumn() + lastToken.getText().length();
            }

            Token eofToken = new Token(TokenType.EOF, eofLine, eofCol, "\0", filePath);
            return eofToken;
        }

        System.out.println("take: "  + tokenList.get(position).toString());

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

    @Override
    public void seek(int position) {
        this.position = position;
    }

    @Override
    public Token peek(int lookAhead) {
        return tokenList.get(position + lookAhead);
    }
}

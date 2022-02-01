package raccoonlang.tokenizer;

public class TokenMismatchException extends RuntimeException {
    public TokenMismatchException(Token token, TokenType tokenType) {
        //TODO: better exception message
        super("Expected '" + tokenType + "' but got '" + token.getTokenType() + "'");
    }
}

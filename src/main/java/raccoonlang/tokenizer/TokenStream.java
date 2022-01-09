package raccoonlang.tokenizer;

public interface TokenStream {

    Token take();
    Token take(TokenType tokenType);
    int size();
}

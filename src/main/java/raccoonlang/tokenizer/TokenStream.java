package raccoonlang.tokenizer;

public interface TokenStream {

    Token take();
    Token take(TokenType tokenType);
    int size();
    void seek(int position);

    Token peek(int lookAhead);

    int getPosition();
}

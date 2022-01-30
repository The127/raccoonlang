namespace Raccoonlang.Tokenizer;

public interface ITokenStream
{
    Token take();
    Token take(TokenType tokenType);
    int size();

    Token peek(int peekOffset);
}
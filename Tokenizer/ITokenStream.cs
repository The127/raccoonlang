namespace Raccoonlang.Tokenizer;

public interface ITokenStream
{
    Token Take();
    Token Take(TokenType tokenType);
    int Size();

    Token Peek(int peekOffset);
}
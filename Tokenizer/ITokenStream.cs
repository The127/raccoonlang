namespace Raccoonlang.Tokenizer;

public interface ITokenStream
{
    Token Take();
    Token Take(TokenType tokenType);
    int Size();
    void Seek(int pos);
    Token Peek(int peekOffset);
}
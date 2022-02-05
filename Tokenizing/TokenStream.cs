namespace Raccoonlang.Tokenizing;

using System.Collections;

using Exceptions;

public class TokenStream : ITokenStream
{

    public int Position {get; private set;}
    public string FilePath {get;}
    private List<Token> tokenList = new List<Token>();

    public TokenStream(string filePath, List<Token> tokenList) 
    {
        this.FilePath = filePath;
        this.tokenList = tokenList;
    }

    public Token Take()
    {
        if (Position >= this.Size()) {
            int eofLine = 0;
            int eofCol = 0;

            if (tokenList.Count() > 0 ) {
                Token lastToken = tokenList[tokenList.Count()-1];
                eofLine = lastToken.Line;
                eofCol = lastToken.Column + lastToken.Text.Length;
            }

            return new Token(TokenType.EOF, eofLine, eofCol, "\n", this.FilePath);
        }

        Console.WriteLine("Pos before take: {0}", this.Position);
        Console.WriteLine("take: {0}", this.tokenList[Position].ToString());

        return this.tokenList[Position++];
    }

    public Token Take(TokenType tokenType)
    {
        Token t = this.Take();
        if (t.Type != tokenType) {
            throw new TokenMismatchException(t, tokenType);
        }

        return t;
    }

    public int Size()
    {
        return this.tokenList.Count();
    }

    public Token Peek(int peekOffset)
    {
        int pos = this.Position;
        this.Position += peekOffset;

        Token res = this.Take();
        this.Position = pos;
        return res;
    }

    public void Seek(int pos)
    {
        this.Position = pos;
    }
}
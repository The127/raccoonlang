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

    public Token Current()
    {
        return this.tokenList[this.Position];
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

    public void Skip()
    {
        this.Skip(1);
    }

    public void Skip(int skipAmount)
    {   
        this.Position += skipAmount;
    }

    public Token Peek(int peekOffset)
    {
        return this.tokenList[Position+peekOffset];
    }

    public void Seek(int pos)
    {
        this.Position = pos;
    }
}
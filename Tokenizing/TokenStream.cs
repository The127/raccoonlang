namespace Raccoonlang.Tokenizing;

using System.Collections;

using Exceptions;

public class TokenStream : ITokenStream
{

    public int Position {get; private set;}
    public string FilePath {get;}
    private List<Token> _tokenList = new List<Token>();

    public TokenStream(string filePath, List<Token> tokenList) 
    {
        this.FilePath = filePath;
        this._tokenList = tokenList;
    }

    public Token Current()
    {
        return this._tokenList[this.Position];
    }

    public Token Take()
    {
        if (Position >= this.Size()) {
            int eofLine = 0;
            int eofCol = 0;

            if (_tokenList.Count() > 0 ) {
                Token lastToken = _tokenList[_tokenList.Count()-1];
                eofLine = lastToken.Line;
                eofCol = lastToken.Column + lastToken.Text.Length;
            }

            return new Token(TokenType.Eof, eofLine, eofCol, "\n", this.FilePath);
        }

        Console.WriteLine("take: {0}", this._tokenList[Position].ToString());

        return this._tokenList[Position++];
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
        return this._tokenList.Count();
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
        return this._tokenList[Position+peekOffset];
    }

    public void Seek(int pos)
    {
        this.Position = pos;
    }
}
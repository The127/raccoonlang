namespace Raccoonlang.Tokenizer;

using System.Collections;
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

    public Token take()
    {
        if (Position >= this.size()) {
            int eofLine = 0;
            int eofCol = 0;

            if (tokenList.Count() > 0 ) {
                Token lastToken = tokenList[tokenList.Count()-1];
                eofLine = lastToken.Line;
                eofCol = lastToken.Column + lastToken.Text.Length;
            }

            return new Token(TokenType.EOF, eofLine, eofCol, "\0", this.FilePath);
        }

        Console.WriteLine("take: {0}", this.tokenList[Position]);

        return this.tokenList[Position++];
    }

    public Token take(TokenType tokenType)
    {
        Token t = take();
        if (t.Type != tokenType) {
            // TODO(naomi): exceptions
            //throw new Exception(t, tokenType);
        }

        return t;
    }

    public int size()
    {
        return this.tokenList.Count();
    }

    public Token peek(int peekOffset)
    {
        int pos = this.Position;
        this.Position += peekOffset;

        Token res = take();
        this.Position = pos;
        return res;
    }
}
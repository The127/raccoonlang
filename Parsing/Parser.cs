namespace Raccoonlang.Parsing;

using Tokenizing;
using AST;

public class Parser
{
    public class ParserState
    {
        public int TokenIndex {get;}

        public ParserState(int tokenIndex)
        {
            this.TokenIndex = tokenIndex;
        }
    }

    private TokenStream _tokenStream;

    public Parser(TokenStream stream)
    {
        this._tokenStream = stream;
    }

    public void Skip()
    {
        this._tokenStream.Skip();
    }

    public void Skip(int skipAmount)
    {
        this._tokenStream.Skip(skipAmount);
    }

        public Token Peek()
    {
        return Peek(0);
    }

    public Token Peek(int peek) 
    {
        return this._tokenStream.Peek(peek);
    }

    public Token Take()
    {
        return this._tokenStream.Take();
    }

    public Token Take(TokenType tokenType) 
    {
        return this._tokenStream.Take(tokenType);
    }

    public ParserState ShelfState()
    {
        return new ParserState(_tokenStream.Position);
    }

    public void RestoreState(ParserState state)
    {
        _tokenStream.Seek(state.TokenIndex);
    }

    public void PrintCurrent()
    {
        Console.WriteLine(this._tokenStream.Current());
    }

    public static FileAstNode Parse(TokenStream stream)
    {
        Parser parser = new Parser(stream);
        FileAstNode node = FileAstNode.Parse(parser);
        //parser.Take(TokenType.EOF);
        return node;
    }
}
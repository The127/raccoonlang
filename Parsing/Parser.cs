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

    private TokenStream tokenStream;

    public Parser(TokenStream stream)
    {
        this.tokenStream = stream;
    }

    public void Skip()
    {
        this.tokenStream.Skip();
    }

    public void Skip(int skipAmount)
    {
        this.tokenStream.Skip(skipAmount);
    }

        public Token Peek()
    {
        return Peek(0);
    }

    public Token Peek(int peek) 
    {
        return this.tokenStream.Peek(peek);
    }

    public Token Take()
    {
        return this.tokenStream.Take();
    }

    public Token Take(TokenType tokenType) 
    {
        return this.tokenStream.Take(tokenType);
    }

    public ParserState ShelfState()
    {
        return new ParserState(tokenStream.Position);
    }

    public void RestoreState(ParserState state)
    {
        tokenStream.Seek(state.TokenIndex);
    }

    public void PrintCurrent()
    {
        Console.WriteLine(this.tokenStream.Current());
    }

    public static FileAstNode Parse(TokenStream stream)
    {
        Parser parser = new Parser(stream);
        FileAstNode node = FileAstNode.Parse(parser);
        //parser.Take(TokenType.EOF);
        return node;
    }
}
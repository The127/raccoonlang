namespace Raccoonlang.Parser;

using Tokenizer;

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

    public Token Peek()
    {
        return Peek(0);
    }

    public Token Peek(int peek) 
    {
        return this.tokenStream.Peek(peek);
    }

    public Token take()
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
        tokenStream.Peek(state.TokenIndex);
    }

    // public static FileAstNode Parse(TokenStream stream)
    // {
    //     Parser parser = new Parser(stream);
    //     FileAstNode node = FileAstNode.parse(parser);
    //     parser.Take(TokenType.EOF);
    //     return node;
    // }
}
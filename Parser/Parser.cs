namespace Raccoonlang.Parser;

using Raccoonlang.Tokenizer;

public class Parser
{
    public class ParserState
    {
        private int tokenIndex = 0;

        public ParserState(int tokenIndex)
        {
            this.tokenIndex = tokenIndex;
        }
    }

    private TokenStream tokenStream;

    public Parser(TokenStrem stream)
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
        return new ParserState(tokenStream.GetPosition());
    }

    public void RestoreState(ParserState state)
    {
        tokenStream.Seek(state.tokenIndex);
    }

    // public static FileAstNode Parse(TokenStream stream)
    // {
    //     Parser parser = new Parser(stream);
    //     FileAstNode node = FileAstNode.parse(parser);
    //     parser.Take(TokenType.EOF);
    //     return node;
    // }
}
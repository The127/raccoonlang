namespace Raccoonlang.Parser.AST;

using Tokenizer;

public class FunctionBodyAstNode
{
    public static FunctionBodyAstNode Parse(Parser parser)
    {
        FunctionBodyAstNode node = new FunctionBodyAstNode();

        parser.Take(TokenType.OPEN_CURLY);
        // TODO: actually get body
        parser.Take(TokenType.CLOSE_CURLY);

        return node;
    }
}
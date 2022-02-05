namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class FunctionBodyAstNode
{
    public static FunctionBodyAstNode Parse(Parser parser)
    {
        FunctionBodyAstNode node = new FunctionBodyAstNode();

        parser.Take(TokenType.OpenCurly);
        // TODO: actually get body
        parser.Take(TokenType.CloseCurly);

        return node;
    }
}
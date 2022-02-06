namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class FunctionBodyAstNode
{
    public List<IStatement> Statements { get; set; } = new();
    
    public static FunctionBodyAstNode Parse(Parser parser)
    {
        FunctionBodyAstNode node = new FunctionBodyAstNode();

        if (parser.Peek().Type == TokenType.OpenCurly)
        {
            parser.Take(TokenType.OpenCurly);
            while (parser.Peek().Type != TokenType.CloseCurly)
            {
                node.Statements.Add(StatementAstNode.Parse(parser));
            }
            parser.Take(TokenType.CloseCurly);
        }
        else
        {
            parser.Take(TokenType.LambdaArrow);
            node.Statements.Add(StatementAstNode.Parse(parser));
        }

        return node;
    }
}
namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class FunctionBodyAstNode
{
    public List<IStatement> Statements { get; set; } = new();

    public static FunctionBodyAstNode Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception("awawaawawawa");
        return node;
    }
    
    public static FunctionBodyAstNode? TryParse(Parser parser)
    {
        FunctionBodyAstNode node = new FunctionBodyAstNode();

        if (parser.Peek().Type == TokenType.OpenCurly)
        {
            parser.Take(TokenType.OpenCurly);
            while (true)
            {
                var statement = StatementAstNode.TryParse(parser);
                if (statement == null) break;
                node.Statements.Add(statement);
            }
            parser.Take(TokenType.CloseCurly);
        }
        else if(parser.Peek().Type == TokenType.LambdaArrow)
        {
            parser.Take(TokenType.LambdaArrow);
            node.Statements.Add(StatementAstNode.Parse(parser));
        }
        else
        {
            return null;
        }

        return node;
    }
}
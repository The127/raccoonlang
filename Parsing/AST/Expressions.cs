using Raccoonlang.Tokenizing;

namespace Raccoonlang.Parsing.AST;

public class ExpressionAstNode
{
    public static ExpressionAstNode Parse(Parser parser)
    {
        var expression = TryParse(parser);
        if (expression == null) throw new System.Exception("fucky wucky happened");
        return expression;
    }

    public static ExpressionAstNode? TryParse(Parser parser)
    {
        //TODO
        return new ExpressionAstNode();
    }
}

public class ConstantExpressionAstNode
{
    public static ConstantExpressionAstNode Parse(Parser parser)
    {
        //TODO
        return new ConstantExpressionAstNode();
    }
}

public class VariableNameExpressionAstNode
{
    public List<Token> NameParts { get; set; } = new();
    
    public static VariableNameExpressionAstNode Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception("oh noes");
        return node;
    }

    public static VariableNameExpressionAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();

        if (parser.Peek().Type != TokenType.Identifier) return null;
        
        VariableNameExpressionAstNode node = new();
        node.NameParts.Add(parser.Take(TokenType.Identifier));
        while (parser.Peek().Type == TokenType.Dot)
        {
            parser.Take(TokenType.Dot);
            
            if (parser.Peek().Type != TokenType.Identifier)
            {
                parser.RestoreState(parserState);
                return null;
            }
            node.NameParts.Add(parser.Take(TokenType.Identifier));
        }
        return node;
    }
}
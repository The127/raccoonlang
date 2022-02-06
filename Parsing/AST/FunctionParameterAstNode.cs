namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class FunctionParameterAstNode
{
    public FqtnAstNode? ParamType { get; set; }
    public Token? ParamName { get; set; }

    public static FunctionParameterAstNode Parse(Parser parser)
    {
        FunctionParameterAstNode node = new FunctionParameterAstNode();
        node.ParamType = FqtnAstNode.Parse(parser);
        node.ParamName = parser.Take(TokenType.Identifier);
        return node;
    }

    public override string ToString()
    {
        if (ParamType != null && ParamName != null)
        {
            return "FunctionParameterAstNode{" +
                   "paramType=" + ParamType +
                   ", paramName=" + ParamName +
                   "}";
        }
        else
        {
            return "FunctionParameterAstNode{}";
        }
    }
}

public class FunctionParametersAstNode
{
    public List<FunctionParameterAstNode> ParamList { get; set; } = new List<FunctionParameterAstNode>();

    public static FunctionParametersAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.OpenParen) return null;
        return Parse(parser);
    }
    
    public static FunctionParametersAstNode Parse(Parser parser)
    {
        FunctionParametersAstNode node = new FunctionParametersAstNode();

        parser.Take(TokenType.OpenParen);

        if (parser.Peek().Type != TokenType.CloseParen)
        {
            node.ParamList.Add(FunctionParameterAstNode.Parse(parser));
            while (parser.Peek().Type == TokenType.Comma)
            {
                parser.Take(TokenType.Comma);
                node.ParamList.Add(FunctionParameterAstNode.Parse(parser));
            }
        }

        parser.Take(TokenType.CloseParen);
        return node;
    }

    public override string ToString()
    {
        return "FunctionParametersAstNode{" +
               "paramList=" + ParamList.ToArray() +
               "}";
    }
}
namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class FunctionParameterAstNode
{
    public FqtnAstNode? paramType;
    public Token? paramName;

    public static FunctionParameterAstNode Parse(Parser parser)
    {
        FunctionParameterAstNode node = new FunctionParameterAstNode();
        node.paramType = FqtnAstNode.Parse(parser);
        parser.Skip();
        node.paramName = parser.Take(TokenType.IDENTIFIER);
        return node;
    }

    public override string ToString()
    {   
        if (paramType != null && paramName != null) {
            return "FunctionParameterAstNode{" +
                    "paramType=" + paramType.ToString() +
                    ", paramName=" + paramName.ToString() +
                    "}";
        } else {
            return "FunctionParameterAstNode{}";
        }
    }
}

public class FunctionParametersAstNode
{
    public List<FunctionParameterAstNode> paramList = new List<FunctionParameterAstNode>();

    public static FunctionParametersAstNode Parse(Parser parser)
    {
        FunctionParametersAstNode node = new FunctionParametersAstNode();

        parser.Take(TokenType.OPEN_PAREN);

        if (parser.Peek().Type != TokenType.CLOSE_PAREN) {

            node.paramList.Add(FunctionParameterAstNode.Parse(parser));

            do {
                parser.Skip(2);
                node.paramList.Add(FunctionParameterAstNode.Parse(parser));
            } while(parser.Peek(1).Type == TokenType.COMMA);
        }

        parser.Take(TokenType.CLOSE_PAREN);
        return node;
    }

    public override string ToString()
    {
        return "FunctionParametersAstNode{" +
                "paramList=" + paramList.ToArray().ToString() +
                "}";
    }
}
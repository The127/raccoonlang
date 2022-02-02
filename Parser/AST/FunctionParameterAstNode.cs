namespace Raccoonlang.Parser.AST;

using Tokenizer;

public class FunctionParameterAstNode
{
    public FqtnAstNode? paramType;
    public Token? paramName;

    public static FunctionParameterAstNode Parse(Parser parser)
    {
        FunctionParameterAstNode node = new FunctionParameterAstNode();
        node.paramType = FqtnAstNode.Parse(parser);
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
            
            while(parser.Peek().Type == TokenType.COMMA) {
                parser.Take();
                node.paramList.Add(FunctionParameterAstNode.Parse(parser));
            }
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
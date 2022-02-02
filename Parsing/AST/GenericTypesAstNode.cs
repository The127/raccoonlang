namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class GenericTypesAstNode
{
    public List<Token> GenericTypeNames = new List<Token>();

    public static GenericTypesAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.OP_LT) return null;

        parser.Take();

        GenericTypesAstNode node = new GenericTypesAstNode();

        while (parser.Peek().Type == TokenType.COMMA) {
            parser.Take();
            node.GenericTypeNames.Add(parser.Take(TokenType.IDENTIFIER));
        }

        parser.Take(TokenType.OP_GT);
        return node;
    }

    public override string ToString()
    {
        return "GenericTypesAstNode{\nGenericTypeNames="+GenericTypeNames.ToArray().ToString()+"\n}";
    }
}
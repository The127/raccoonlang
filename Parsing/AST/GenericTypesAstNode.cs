namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class GenericTypesAstNode
{
    public List<Token> GenericTypeNames { get; set; } = new List<Token>();

    public static GenericTypesAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.OpLt) return null;
        parser.Take(TokenType.OpLt);

        GenericTypesAstNode node = new GenericTypesAstNode();

        node.GenericTypeNames.Add(parser.Take(TokenType.Identifier));
        while (parser.Peek().Type == TokenType.Comma) {
            parser.Take(TokenType.Comma);
            node.GenericTypeNames.Add(parser.Take(TokenType.Identifier));
        }

        parser.Take(TokenType.OpGt);
        return node;
    }

    public override string ToString()
    {
        return "GenericTypesAstNode{\nGenericTypeNames="+GenericTypeNames.ToArray().ToString()+"\n}";
    }
}
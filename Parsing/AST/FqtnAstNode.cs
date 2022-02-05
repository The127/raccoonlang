namespace Raccoonlang.Parsing.AST;

using Tokenizing;

// fully qualified type name
public class FqtnAstNode 
{
    public List<Token> Identifiers = new List<Token>();
    public GenericTypesAstNode? Node;

    public static FqtnAstNode Parse(Parser parser)
    {
        FqtnAstNode node = new FqtnAstNode();

        node.Identifiers.Add(parser.Take(TokenType.IDENTIFIER));

        while(parser.Peek().Type == TokenType.DOT) {
            parser.Take();
            node.Identifiers.Add(parser.Take(TokenType.IDENTIFIER));
        }

        node.Node = GenericTypesAstNode.TryParse(parser);
        if (node.Node == null) Console.WriteLine("Could not find a generic here! This might be right, or wrong, check source!");
        return node;
    }

    public override string ToString() {
        return "FqtnAstNode{identifiers=" + string.Join(",", Identifiers) + "}";
    }
}
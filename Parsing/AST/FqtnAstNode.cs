namespace Raccoonlang.Parsing.AST;

using Tokenizing;

// fully qualified type name
public class FqtnAstNode 
{
    public List<Token> Identifiers { get; set; } = new();
    public GenericTypesAstNode? GenericTypesAstNode { get; set; }

    public static FqtnAstNode Parse(Parser parser)
    {
        FqtnAstNode node = new FqtnAstNode();

        node.Identifiers.Add(parser.Take(TokenType.Identifier));

        while(parser.Peek().Type == TokenType.Dot) {
            parser.Take(TokenType.Dot);
            node.Identifiers.Add(parser.Take(TokenType.Identifier));
        }

        node.GenericTypesAstNode = GenericTypesAstNode.TryParse(parser);
        return node;
    }

    public override string ToString() {
        return "FqtnAstNode{identifiers=[" + string.Join(",", Identifiers) + $"], GenericTypesAstNode={GenericTypesAstNode}}}";
    }
}
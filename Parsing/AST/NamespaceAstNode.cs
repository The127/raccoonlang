namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class NamespaceAstNode
{
    public FqtnAstNode Name {get; set;}

    public static NamespaceAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Namespace) return null;

        NamespaceAstNode node = new NamespaceAstNode();
        parser.Take(TokenType.Namespace);
        node.Name = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.Semicolon);

        return node;
    }

    public override string ToString() => $"NamespaceAstNode={{\nNode={Name}}}";

    public string Compile()
    {
        return string.Join(".", Name.Identifiers.Select(x => x.Text));
    }
}
namespace Raccoonlang.Parser.AST;

using Tokenizer;

public class NamespaceAstNode
{
    public FqtnAstNode? Node {get; private set;}

    public static NamespaceAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.NAMESPACE) {
            return null;
        }

        NamespaceAstNode node = new NamespaceAstNode();
        parser.Take();
        node.Node = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.SEMICOLON);

        return node;
    }
}
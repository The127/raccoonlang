namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class InterfaceDefinitionAstNode 
{
    private ModifiersAstNode? modifiers;
    private Token? name;
    private GenericTypesAstNode? genericTypes;
    private GenericTypeConstraintsAstNode? genericConstraints;
    private InterfaceBodyAstNode? bodyContainer;

    public static InterfaceDefinitionAstNode? TryParse(Parser parser)
    {
        InterfaceDefinitionAstNode node = new InterfaceDefinitionAstNode();

        if (parser.Peek(1).Type != TokenType.INTERFACE) return null;

        node.modifiers = ModifiersAstNode.Parse(parser);

        parser.Skip(3); // skip the interface token + whitespaces

        node.name = parser.Take(TokenType.IDENTIFIER);
        node.genericTypes = GenericTypesAstNode.TryParse(parser);
        node.genericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.bodyContainer = InterfaceBodyAstNode.Parse(parser);

        return node;
    }
}
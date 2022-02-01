namespace Raccoonlang.Parser.AST;

using Tokenizer;

public class InterfaceDefinitionAstNode 
{
    private ModifiersAstNode? modifiers;
    private Token? name;
    private GenericTypesAstNode? genericTypes;
    private GenericTypeConstraintsAstNode? genericConstraints;
    private InterfaceBodyAstNode? bodyContainer;

    public static InterfaceDefinitionAstNode? TryParse(Parser parser)
    {
        Parser.ParserState state = parser.ShelfState();
        InterfaceDefinitionAstNode node = new InterfaceDefinitionAstNode();

        node.modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.INTERFACE) {
            parser.RestoreState(state);
            return null;
        }

        parser.Take();

        node.name = parser.Take(TokenType.IDENTIFIER);
        node.genericTypes = GenericTypesAstNode.TryParse(parser);
        node.genericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.bodyContainer = InterfaceBodyAstNode.Parse(parser);

        return node;
    }
}
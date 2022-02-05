namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class InterfaceDefinitionAstNode : ITypeDef
{
    private ModifiersAstNode? Modifiers { get; set; }
    private Token? Name { get; set; }
    private GenericTypesAstNode? GenericTypes { get; set; }
    private GenericTypeConstraintsAstNode? GenericConstraints { get; set; }
    private InterfaceBodyAstNode? BodyContainer { get; set; }

    public static InterfaceDefinitionAstNode? TryParse(Parser parser)
    {
        InterfaceDefinitionAstNode node = new InterfaceDefinitionAstNode();

        var parserState = parser.ShelfState();
        node.Modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.Interface)
        {
            parser.RestoreState(parserState);
            return null;
        }

        parser.Take(TokenType.Interface);

        node.Name = parser.Take(TokenType.Identifier);
        node.GenericTypes = GenericTypesAstNode.TryParse(parser);
        node.GenericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.BodyContainer = InterfaceBodyAstNode.Parse(parser);

        return node;
    }
}
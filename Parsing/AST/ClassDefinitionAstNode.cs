namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class ClassDefinitionAstNode : ITypeDef
{
    public ModifiersAstNode? Modifiers { get; set; }
    public Token? Name { get; set; }
    public GenericTypesAstNode? GenericTypes{ get; set; }
    public GenericTypeConstraintsAstNode? GenericConstraints { get; set; }
    public ClassBodyAstNode? BodyContainer { get; set; }

    public static ClassDefinitionAstNode? TryParse(Parser parser)
    {
        ClassDefinitionAstNode node = new ClassDefinitionAstNode();

        var parserState = parser.ShelfState();
        node.Modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.Class)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.Class);

        node.Name = parser.Take(TokenType.Identifier);
        node.GenericTypes = GenericTypesAstNode.TryParse(parser);
        node.GenericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.BodyContainer = ClassBodyAstNode.Parse(parser);

        return node;
    }

    public override string ToString() => $"ClassDefinitionAstNode{{Modifiers={Modifiers}, Name={Name}, GenericTypes={GenericTypes}, GenericConstraints={GenericConstraints}, BodyContainer={BodyContainer}}}";
}
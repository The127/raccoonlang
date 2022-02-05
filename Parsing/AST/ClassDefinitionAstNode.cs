namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class ClassDefinitionAstNode
{
    public ModifiersAstNode? modifiers;
    public Token? name;
    public GenericTypesAstNode? genericTypes;
    public GenericTypeConstraintsAstNode? genericConstraints;
    public ClassBodyAstNode? bodyContainer;

    public static ClassDefinitionAstNode? TryParse(Parser parser)
    {
        Parser.ParserState state = parser.ShelfState();
        
        ClassDefinitionAstNode node = new ClassDefinitionAstNode();

        node.modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.CLASS) {
            Console.WriteLine("Restored state in ClassDefinition");
            parser.RestoreState(state);
            return null;
        }
        parser.Take();

        node.name = parser.Take(TokenType.IDENTIFIER);
        node.genericTypes = GenericTypesAstNode.TryParse(parser);
        node.genericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.bodyContainer = ClassBodyAstNode.Parse(parser);

        return node;
    }
}
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
        
        ClassDefinitionAstNode node = new ClassDefinitionAstNode();

        node.modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek(1).Type != TokenType.CLASS) return null;

        node.modifiers = ModifiersAstNode.Parse(parser);

        parser.Skip(); // skip the class token 

        node.name = parser.Take(TokenType.IDENTIFIER);
        node.genericTypes = GenericTypesAstNode.TryParse(parser);
        node.genericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.bodyContainer = ClassBodyAstNode.Parse(parser);

        return node;
    }
}
namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class ClassDefinitionAstNode : ITypeDef
{
    public ModifiersAstNode? Modifiers { get; set; }
    public Token? Name { get; set; }
    public GenericTypesAstNode? GenericTypes{ get; set; }
    public ExtendsAstNode? Parent { get; set; }
    public ImplementsAstNode Interfaces { get; set; }
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
        node.Parent = ExtendsAstNode.TryParse(parser);
        node.Interfaces = ImplementsAstNode.Parse(parser);
        node.GenericConstraints = GenericTypeConstraintsAstNode.Parse(parser);
        node.BodyContainer = ClassBodyAstNode.Parse(parser);

        return node;
    }

    public override string ToString() => $"ClassDefinitionAstNode{{Modifiers={Modifiers}, Name={Name}, GenericTypes={GenericTypes}, GenericConstraints={GenericConstraints}, BodyContainer={BodyContainer}}}";
}

public class ExtendsAstNode
{
    public FqtnAstNode ParentType { get; set; }
    public static ExtendsAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Extends) return null;
        parser.Take(TokenType.Extends);
        ExtendsAstNode node = new();
        node.ParentType = FqtnAstNode.Parse(parser);
        return node;
    }
}

public class ImplementsAstNode
{
    public List<FqtnAstNode> ImplementedInterfaces { get; set; } = new();
    
    public static ImplementsAstNode Parse(Parser parser)
    {
        ImplementsAstNode node = new();
        if (parser.Peek().Type != TokenType.Implements) return node;
        parser.Take(TokenType.Implements);

        node.ImplementedInterfaces.Add(FqtnAstNode.Parse(parser));
        while (parser.Peek().Type == TokenType.Comma)
        {
            parser.Take(TokenType.Comma);
            node.ImplementedInterfaces.Add(FqtnAstNode.Parse(parser));
        }
        
        return node;
    }
}
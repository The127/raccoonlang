namespace Raccoonlang.Parsing.AST;

using LLVMSharp;

using Tokenizing;
using Utils;

public class InterfaceDefinitionAstNode : ITypeDef
{
    public ModifiersAstNode? Modifiers { get; set; }
    public Token? Name { get; set; }
    public GenericTypesAstNode? GenericTypes { get; set; }
    public GenericTypeConstraintsAstNode? GenericConstraints { get; set; }
    public InterfaceBodyAstNode? BodyContainer { get; set; }

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

    public override string ToString() =>
        $"InterfaceDefinitionAstNode{{\nModifiers={Modifiers}, Name={Name}, GenericTypes={GenericTypes}, GenericConstraints={GenericConstraints}, BodyContainer={BodyContainer}}}";

    public void Compile(LLVMContextRef context, IRBuilder irBuilder, Module module)
    {
        CompilerLogger.Error("Not implemented yet!");
        Environment.Exit(1);
    }
}
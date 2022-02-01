namespace Raccoonlang.Parser.AST;

using Tokenizer;

public class ClassDefinitionAstNode
{
    public ModifiersAstNode? modifiers;
    public Token? name;
    public GenericTypesAstNode? genericTypes;
    public GenericTypeConstraintsAstNode? genericConstraints;
    public ClassBodyAstNode? bodyContainer;
}
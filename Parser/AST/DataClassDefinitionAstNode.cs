namespace Raccoonlang.Parser.AST;

using Tokenizer;

public class DataClassDefinitionAstNode
{
    public ModifiersAstNode? modifiers;
    public Token? name;
    public GenericTypesAstNode? genericTypes;
    //public FunctionParametersAstNode? params;
    public GenericTypeConstraintsAstNode? genericConstraints;
    public DataClassBodyAstNode? bodyContainer;
}
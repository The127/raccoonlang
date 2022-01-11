package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;

public class TypeDefinitionAstNode {

    public InterfaceDefinitionAstNode interfaceDefinitionAstNode;
    public ClassDefinitionAstNode classDefinitionAstNode;
    public DataClassDefinitionAstNode dataClassDefinitionAstNode;
    public FunctionDefinitionAstNode functionDefinitionAstNode;

    public static TypeDefinitionAstNode tryParse(Parser parser) {
        TypeDefinitionAstNode typeDefinitionAstNode = new TypeDefinitionAstNode();

        typeDefinitionAstNode.interfaceDefinitionAstNode = InterfaceDefinitionAstNode.tryParse(parser);
        if(typeDefinitionAstNode.interfaceDefinitionAstNode == null){
            typeDefinitionAstNode.classDefinitionAstNode = ClassDefinitionAstNode.tryParse(parser);
        }
        if(typeDefinitionAstNode.classDefinitionAstNode == null){
            typeDefinitionAstNode.dataClassDefinitionAstNode = DataClassDefinitionAstNode.tryParse(parser);
        }
        if(typeDefinitionAstNode.dataClassDefinitionAstNode == null){
            typeDefinitionAstNode.functionDefinitionAstNode = FunctionDefinitionAstNode.tryParse(parser);
        }

        return typeDefinitionAstNode;
    }
}

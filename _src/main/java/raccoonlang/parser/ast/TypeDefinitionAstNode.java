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
        }else{
            return typeDefinitionAstNode;
        }

        if(typeDefinitionAstNode.classDefinitionAstNode == null){
            typeDefinitionAstNode.dataClassDefinitionAstNode = DataClassDefinitionAstNode.tryParse(parser);
        }else{
            return typeDefinitionAstNode;
        }

        if(typeDefinitionAstNode.dataClassDefinitionAstNode == null){
            typeDefinitionAstNode.functionDefinitionAstNode = FunctionDefinitionAstNode.tryParse(parser);
        }else{
            return typeDefinitionAstNode;
        }

        return null;
    }

    @Override
    public String toString() {
        return "TypeDefinitionAstNode{" +
                "interfaceDefinitionAstNode=" + (interfaceDefinitionAstNode == null ? "" : interfaceDefinitionAstNode.toString()) +
                ", classDefinitionAstNode=" + (classDefinitionAstNode == null ? "" : classDefinitionAstNode.toString()) +
                ", dataClassDefinitionAstNode=" + (dataClassDefinitionAstNode == null ? "" : dataClassDefinitionAstNode.toString()) +
                ", functionDefinitionAstNode=" + (functionDefinitionAstNode == null ? "" : functionDefinitionAstNode.toString()) +
                '}';
    }
}

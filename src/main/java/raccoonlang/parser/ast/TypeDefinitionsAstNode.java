package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;

import java.util.ArrayList;
import java.util.List;

public class TypeDefinitionsAstNode {
    public List<TypeDefinitionAstNode> typeDefinitionAstNodes = new ArrayList<>();

    public static TypeDefinitionsAstNode parse(Parser parser) {
        TypeDefinitionsAstNode typeDefinitionsAstNode = new TypeDefinitionsAstNode();

        do{
            TypeDefinitionAstNode typeDefinitionAstNode = TypeDefinitionAstNode.tryParse(parser);
            if(typeDefinitionAstNode != null){
                typeDefinitionsAstNode.typeDefinitionAstNodes.add(typeDefinitionAstNode);
            }
        }while (typeDefinitionsAstNode != null);

        return typeDefinitionsAstNode;
    }

    @Override
    public String toString() {
        return "TypeDefinitionsAstNode{" +
                "typeDefinitionAstNodes=" + typeDefinitionAstNodes.stream().map(x -> x.toString()).reduce((a,b) -> a + ", " + b) +
                '}';
    }
}

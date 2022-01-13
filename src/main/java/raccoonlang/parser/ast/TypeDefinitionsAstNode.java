package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;

import java.util.ArrayList;
import java.util.List;

public class TypeDefinitionsAstNode {
    public List<TypeDefinitionAstNode> typeDefinitionAstNodes = new ArrayList<>();

    public static TypeDefinitionsAstNode parse(Parser parser) {
        TypeDefinitionsAstNode typeDefinitionsAstNode = new TypeDefinitionsAstNode();

        while(true){
            TypeDefinitionAstNode typeDefinitionAstNode = TypeDefinitionAstNode.tryParse(parser);
            if(typeDefinitionAstNode != null){
                typeDefinitionsAstNode.typeDefinitionAstNodes.add(typeDefinitionAstNode);
            }else{
                break;
            }
        }

        return typeDefinitionsAstNode;
    }

    @Override
    public String toString() {
        return "TypeDefinitionsAstNode{" +
                "typeDefinitionAstNodes=" + typeDefinitionAstNodes.stream().map(x -> x.toString()).reduce((a,b) -> a + ", " + b) +
                '}';
    }
}

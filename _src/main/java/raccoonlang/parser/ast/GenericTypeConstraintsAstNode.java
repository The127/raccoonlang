package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class GenericTypeConstraintsAstNode {

    public List<GenericTypeConstraintAstNode> genericTypeConstraintList = new ArrayList<>();

    public static GenericTypeConstraintsAstNode parse(Parser parser) {
        GenericTypeConstraintsAstNode genericTypeConstraintsAstNode = new GenericTypeConstraintsAstNode();

        while(true){
            GenericTypeConstraintAstNode genericTypeConstraintAstNode = GenericTypeConstraintAstNode.tryParse(parser);
            if(genericTypeConstraintAstNode == null){
                break;
            }
            genericTypeConstraintsAstNode.genericTypeConstraintList.add(genericTypeConstraintAstNode);
        }

        return genericTypeConstraintsAstNode;
    }

    @Override
    public String toString() {
        return "GenericTypeConstraintsAstNode{" +
                "genericTypeConstraintList=" + genericTypeConstraintList.stream().map(x -> x.toString()).reduce((a, b) -> a + ", " + b).orElse("") +
                '}';
    }
}

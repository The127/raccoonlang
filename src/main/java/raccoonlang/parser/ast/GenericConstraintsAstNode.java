package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class GenericConstraintsAstNode {

    public List<GenericConstraintAstNode> genericConstraintAstNodes = new ArrayList<>();

    public static GenericConstraintsAstNode parse(Parser parser) {
        GenericConstraintsAstNode genericConstraintsAstNode = new GenericConstraintsAstNode();

        genericConstraintsAstNode.genericConstraintAstNodes.add(GenericConstraintAstNode.parse(parser));
        while(parser.peek().getTokenType() == TokenType.COMMA){
            genericConstraintsAstNode.genericConstraintAstNodes.add(GenericConstraintAstNode.parse(parser));
        }

        return genericConstraintsAstNode;
    }
}

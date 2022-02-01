package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class GenericTypeConstraintAstNode {

    public List<GenericConstraintsAstNode> genericConstraintsAstNodes = new ArrayList<>();

    public static GenericTypeConstraintAstNode tryParse(Parser parser) {
        Token token = parser.peek();
        if(token.getTokenType() != TokenType.WHERE){
            return null;
        }

        parser.take();
        parser.take(TokenType.COLON);

        GenericTypeConstraintAstNode genericTypeConstraintAstNode = new GenericTypeConstraintAstNode();

        genericTypeConstraintAstNode.genericConstraintsAstNodes.add(GenericConstraintsAstNode.parse(parser));
        while(true){
            if(parser.peek().getTokenType() != TokenType.COMMA) break;
            parser.take();
            genericTypeConstraintAstNode.genericConstraintsAstNodes.add(GenericConstraintsAstNode.parse(parser));
        }

        return genericTypeConstraintAstNode;
    }
}

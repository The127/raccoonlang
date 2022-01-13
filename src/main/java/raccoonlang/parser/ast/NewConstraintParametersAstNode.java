package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class NewConstraintParametersAstNode {

    public List<FqtnAstNode> fqtnAstNodes = new ArrayList<>();

    public static NewConstraintParametersAstNode tryParse(Parser parser) {
        if(parser.peek().getTokenType() != TokenType.OPEN_PAREN) return null;
        parser.take();

        NewConstraintParametersAstNode newConstraintParametersAstNode = new NewConstraintParametersAstNode();

        if (parser.peek().getTokenType() == TokenType.IDENTIFIER) {
            while (true){
                newConstraintParametersAstNode.fqtnAstNodes.add(FqtnAstNode.parse(parser));
                if(parser.peek().getTokenType() != TokenType.COMMA) break;
                parser.take(TokenType.COMMA);
            }
        }

        parser.take(TokenType.CLOSE_PAREN);
        return newConstraintParametersAstNode;
    }
}

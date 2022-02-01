package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class GenericTypesAstNode {

    public List<Token> genericTypeNames = new ArrayList<>();

    public static GenericTypesAstNode tryParse(Parser parser) {
        if(parser.peek().getTokenType() != TokenType.OP_LT) return null;
        parser.take();

        GenericTypesAstNode genericTypesAstNode = new GenericTypesAstNode();

        while (parser.peek().getTokenType() == TokenType.COMMA){
            parser.take();
            genericTypesAstNode.genericTypeNames.add(parser.take(TokenType.IDENTIFIER));
        }

        parser.take(TokenType.OP_GT);
        return genericTypesAstNode;
    }

    @Override
    public String toString() {
        return "GenericTypesAstNode{" +
                "genericTypeNames=" + genericTypeNames.stream().map(x -> x.getText()).reduce((a, b) -> a + ", " + b) +
                '}';
    }
}

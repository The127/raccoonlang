package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class FqtnAstNode {

    public List<Token> identifiers = new ArrayList<>();
    public GenericTypesAstNode genericTypesAstNode;

    public static FqtnAstNode parse(Parser parser) {
        FqtnAstNode fqtnAstNode = new FqtnAstNode();

        fqtnAstNode.identifiers.add(parser.take(TokenType.IDENTIFIER));

        while(parser.peek().getTokenType() == TokenType.DOT){
            parser.take();
            fqtnAstNode.identifiers.add(parser.take(TokenType.IDENTIFIER));
        }

        fqtnAstNode.genericTypesAstNode = GenericTypesAstNode.tryParse(parser);

        return fqtnAstNode;
    }

    @Override
    public String toString() {
        return "FqtnAstNode{" +
                "identifiers=" + identifiers.stream().map(x -> x.getText()).reduce((a, b) -> a + "." + b).orElse("") +
                '}';
    }
}

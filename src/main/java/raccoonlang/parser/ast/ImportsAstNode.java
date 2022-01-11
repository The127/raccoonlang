package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

import java.util.ArrayList;
import java.util.List;

public class ImportsAstNode {
    List<ImportAstNode> importAstNodes = new ArrayList<>();

    public static ImportsAstNode parse(Parser parser) {
        ImportsAstNode importsAstNode = new ImportsAstNode();

        while(parser.peek().getTokenType() == TokenType.IMPORT){
            importsAstNode.importAstNodes.add(ImportAstNode.parse(parser));
        }

        return importsAstNode;
    }

    @Override
    public String toString() {
        return "ImportsAstNode{" +
                "importAstNodes=[" + importAstNodes.stream().map(x -> x.importTypeName.toString()).reduce((a, b) -> a + ", " + b).orElse("") +
                "]}";
    }
}

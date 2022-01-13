package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

public class ClassBodyAstNode {
    public static ClassBodyAstNode parse(Parser parser) {
        ClassBodyAstNode classBodyAstNode = new ClassBodyAstNode();

        parser.take(TokenType.OPEN_CURLY);
        parser.take(TokenType.CLOSE_CURLY);

        return classBodyAstNode;
    }
}

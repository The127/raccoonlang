package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

public class InterfaceBodyAstNode {
    public static InterfaceBodyAstNode parse(Parser parser) {
        InterfaceBodyAstNode interfaceBodyAstNode = new InterfaceBodyAstNode();

        parser.take(TokenType.OPEN_CURLY);
        parser.take(TokenType.CLOSE_CURLY);

        return interfaceBodyAstNode;
    }
}

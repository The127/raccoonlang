package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

public class FunctionBodyAstNode {
    public static FunctionBodyAstNode parse(Parser parser) {
        FunctionBodyAstNode functionBodyAstNode = new FunctionBodyAstNode();

        parser.take(TokenType.OPEN_CURLY);
        parser.take(TokenType.CLOSE_CURLY);

        return functionBodyAstNode;
    }
}

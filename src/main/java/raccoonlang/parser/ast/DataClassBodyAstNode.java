package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

public class DataClassBodyAstNode {
    public static DataClassBodyAstNode parse(Parser parser) {
        DataClassBodyAstNode dataClassAstNode = new DataClassBodyAstNode();

        parser.take(TokenType.OPEN_CURLY);
        parser.take(TokenType.CLOSE_CURLY);

        return dataClassAstNode;
    }
}

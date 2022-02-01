package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

public class ImportAstNode {
    public FqtnAstNode importTypeName;

    public static ImportAstNode parse(Parser parser) {
        Parser.ParserState parserState = parser.shelfState();

        ImportAstNode importAstNode = new ImportAstNode();

        parser.take(TokenType.IMPORT);
        importAstNode.importTypeName = FqtnAstNode.parse(parser);
        parser.take(TokenType.SEMICOLON);

        return importAstNode;
    }
}

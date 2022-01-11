package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class DataClassDefinitionAstNode {

    public ModifiersAstNode modifiersAstNode;
    public Token name;
    public GenericTypesAstNode genericTypesAstNode;

    public static DataClassDefinitionAstNode tryParse(Parser parser) {
        Parser.ParserState parserState = parser.shelfState();
        DataClassDefinitionAstNode dataClassDefinitionAstNode = new DataClassDefinitionAstNode();

        dataClassDefinitionAstNode.modifiersAstNode = ModifiersAstNode.parse(parser);

        if(parser.peek().getTokenType() != TokenType.DATA) {
            parser.restore(parserState);
            return null;
        }
        parser.take();
        parser.take(TokenType.CLASS);

        dataClassDefinitionAstNode.name = parser.take(TokenType.IDENTIFIER);
        dataClassDefinitionAstNode.genericTypesAstNode = GenericTypesAstNode.tryParse(parser);

        return dataClassDefinitionAstNode;
    }
}

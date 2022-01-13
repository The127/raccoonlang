package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class ClassDefinitionAstNode {

    public ModifiersAstNode modifiersAstNode;
    public Token name;
    public GenericTypesAstNode genericTypesAstNode;
    public GenericTypeConstraintsAstNode genericTypeConstraintsAstNode;
    public ClassBodyAstNode classBodyAstNode;

    public static ClassDefinitionAstNode tryParse(Parser parser) {
        Parser.ParserState parserState = parser.shelfState();
        ClassDefinitionAstNode classDefinitionAstNode = new ClassDefinitionAstNode();

        classDefinitionAstNode.modifiersAstNode = ModifiersAstNode.parse(parser);

        if(parser.peek().getTokenType() != TokenType.CLASS) {
            parser.restore(parserState);
            return null;
        }
        parser.take();

        classDefinitionAstNode.name = parser.take(TokenType.IDENTIFIER);
        classDefinitionAstNode.genericTypesAstNode = GenericTypesAstNode.tryParse(parser);
        classDefinitionAstNode.genericTypeConstraintsAstNode = GenericTypeConstraintsAstNode.parse(parser);
        classDefinitionAstNode.classBodyAstNode = ClassBodyAstNode.parse(parser);

        return classDefinitionAstNode;
    }
}

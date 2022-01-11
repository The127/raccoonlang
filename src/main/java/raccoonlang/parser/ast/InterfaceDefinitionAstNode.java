package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class InterfaceDefinitionAstNode {

    public ModifiersAstNode modifiersAstNode;
    public Token name;
    public GenericTypesAstNode genericTypesAstNode;

    public static InterfaceDefinitionAstNode tryParse(Parser parser) {
        Parser.ParserState parserState = parser.shelfState();
        InterfaceDefinitionAstNode interfaceDefinitionAstNode = new InterfaceDefinitionAstNode();

        interfaceDefinitionAstNode.modifiersAstNode = ModifiersAstNode.parse(parser);

        if(parser.peek().getTokenType() != TokenType.INTERFACE) {
            parser.restore(parserState);
            return null;
        }
        parser.take();

        interfaceDefinitionAstNode.name = parser.take(TokenType.IDENTIFIER);
        interfaceDefinitionAstNode.genericTypesAstNode = GenericTypesAstNode.tryParse(parser);



        return interfaceDefinitionAstNode;
    }
}

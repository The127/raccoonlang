package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;
import raccoonlang.tokenizer.TokenType;

public class DataClassDefinitionAstNode {

    public ModifiersAstNode modifiersAstNode;
    public Token name;
    public GenericTypesAstNode genericTypesAstNode;
    public FunctionParametersAstNode functionParametersAstNode;
    public GenericTypeConstraintsAstNode genericTypeConstraintsAstNode;
    public DataClassBodyAstNode dataClassBodyAstNode;

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
        dataClassDefinitionAstNode.functionParametersAstNode = FunctionParametersAstNode.parse(parser);
        dataClassDefinitionAstNode.genericTypeConstraintsAstNode = GenericTypeConstraintsAstNode.parse(parser);
        dataClassDefinitionAstNode.dataClassBodyAstNode = DataClassBodyAstNode.parse(parser);

        return dataClassDefinitionAstNode;
    }

    @Override
    public String toString() {
        return "DataClassDefinitionAstNode{" +
                "modifiersAstNode=" + modifiersAstNode +
                ", name=" + name +
                ", genericTypesAstNode=" + (genericTypesAstNode == null ? "" : genericTypesAstNode.toString()) +
                ", functionParametersAstNode=" + functionParametersAstNode +
                ", genericTypeConstraintsAstNode=" + genericTypeConstraintsAstNode +
                ", dataClassBodyAstNode=" + dataClassBodyAstNode +
                '}';
    }
}

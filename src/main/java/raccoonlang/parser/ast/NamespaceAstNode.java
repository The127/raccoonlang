package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenType;

public class NamespaceAstNode {
    public FqtnAstNode namespaceName;

    public static NamespaceAstNode tryParse(Parser parser) {
        if(parser.peek().getTokenType() != TokenType.NAMESPACE){
            return null;
        }

        NamespaceAstNode namespaceAstNode = new NamespaceAstNode();

        parser.take();
        namespaceAstNode.namespaceName = FqtnAstNode.parse(parser);
        parser.take(TokenType.SEMICOLON);

        return namespaceAstNode;
    }

    @Override
    public String toString() {
        return "NamespaceAstNode{" +
                "namespaceName=" + namespaceName.toString() +
                '}';
    }
}

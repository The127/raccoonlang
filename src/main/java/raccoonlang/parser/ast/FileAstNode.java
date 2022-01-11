package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.TokenStream;

public class FileAstNode {
    public ImportsAstNode importsAstNode;
    public NamespaceAstNode namespaceAstNode;
    public TypeDefinitionsAstNode typeDefinitionsAstNode;

    @Override
    public String toString() {
        return "FileAstNode{" +
                "importsAstNode=" + importsAstNode.toString() +
                ", namespaceAstNode=" + (namespaceAstNode == null ? "" : namespaceAstNode.toString()) +
                //", typeDefinitionsAstNode=" + typeDefinitionsAstNode.toString() +
                '}';
    }

    public static FileAstNode parse(Parser parser){
        FileAstNode fileAstNode = new FileAstNode();

        fileAstNode.importsAstNode = ImportsAstNode.parse(parser);
        fileAstNode.namespaceAstNode = NamespaceAstNode.tryParse(parser);

        return fileAstNode;
    }
}

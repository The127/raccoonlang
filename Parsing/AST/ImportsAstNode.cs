namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class ImportsAstNode
{
    public List<ImportAstNode> ImportNodes = new List<ImportAstNode>();

    public static ImportsAstNode Parse(Parser parser)
    {
        ImportsAstNode node = new ImportsAstNode();

        while(parser.Peek().Type == TokenType.IMPORT) {
            node.ImportNodes.Add(ImportAstNode.Parse(parser));
        }

        return node;
    }
}

public class ImportAstNode
{
    public FqtnAstNode? ImportTypeName {get;private set;}

    public static ImportAstNode Parse(Parser parser)
    {
        Parser.ParserState ps = parser.ShelfState();

        ImportAstNode node = new ImportAstNode();

        parser.Take(TokenType.IMPORT);
        node.ImportTypeName = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.SEMICOLON);

        return node;
    }

}
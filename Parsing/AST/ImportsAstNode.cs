namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class ImportsAstNode
{
    public List<ImportAstNode> ImportNodes { get; set; } = new List<ImportAstNode>();

    public static ImportsAstNode Parse(Parser parser)
    {
        ImportsAstNode node = new ImportsAstNode();

        while (true)
        {
            var importAstNode = ImportAstNode.TryParse(parser);
            if (importAstNode == null) return node;
            node.ImportNodes.Add(importAstNode);
        }
    }

    public override string ToString() => $"ImportsAstNode{{\nImportNodes=[{String.Join(",", ImportNodes)}]}}";
}

public class ImportAstNode
{
    public FqtnAstNode? ImportTypeName { get; set; }

    public static ImportAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Import) return null;
        
        ImportAstNode node = new ImportAstNode();

        parser.Take(TokenType.Import);
        node.ImportTypeName = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.Semicolon);

        return node;
    }

    public override string ToString() => $"ImportAstNode{{\nImportTypeName={ImportTypeName}}}";
}
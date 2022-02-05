namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class DataClassBodyAstNode
{
    public List<DataClassMemberAstNode> MemberList { get; set; } = new List<DataClassMemberAstNode>();

    public static DataClassBodyAstNode Parse(Parser parser)
    {
        DataClassBodyAstNode node = new DataClassBodyAstNode();

        if (parser.Peek().Type == TokenType.Semicolon)
        {
            parser.Skip();
            return node;
        }

        parser.Take(TokenType.OpenCurly);
        while (parser.Peek().Type != TokenType.CloseCurly)
        {
            node.MemberList.Add(DataClassMemberAstNode.Parse(parser));
        }

        return node;
    }
}
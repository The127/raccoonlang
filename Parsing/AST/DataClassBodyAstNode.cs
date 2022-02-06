namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class DataClassBodyAstNode
{
    public List<IDataClassMember> MemberList { get; set; } = new();

    public static DataClassBodyAstNode Parse(Parser parser)
    {
        DataClassBodyAstNode node = new DataClassBodyAstNode();

        if (parser.Peek().Type == TokenType.Semicolon)
        {
            parser.Take(TokenType.Semicolon);
            return node;
        }

        parser.Take(TokenType.OpenCurly);
        while (true)
        {
            var member = DataClassMemberAstNode.TryParse(parser);
            if (member == null) break;
            node.MemberList.Add(member);
        }
        parser.Take(TokenType.CloseCurly);

        return node;
    }

    public override string ToString() => $"DataClassBodyAstNode={{MemberList=[{string.Join(",", MemberList)}]}}";
}
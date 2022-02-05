namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class InterfaceBodyAstNode
{
    public List<InterfaceMemberAstNode> MemberList { get; set; } = new List<InterfaceMemberAstNode>();

    public static InterfaceBodyAstNode Parse(Parser parser)
    {
        InterfaceBodyAstNode node = new InterfaceBodyAstNode();
        parser.Take(TokenType.OpenCurly);

        while(parser.Peek().Type != TokenType.CloseCurly) {
            node.MemberList.Add(InterfaceMemberAstNode.Parse(parser));
        }

        parser.Take(TokenType.CloseCurly);
        return node;
    }

    public override string ToString() => $"InterfaceBodyAstNode{{\nMemberList=[{string.Join(",", MemberList)}]}}";
}
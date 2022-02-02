namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class InterfaceBodyAstNode
{
    public List<InterfaceMemberAstNode> memberList = new List<InterfaceMemberAstNode>();

    public static InterfaceBodyAstNode Parse(Parser parser)
    {
        InterfaceBodyAstNode node = new InterfaceBodyAstNode();

        parser.Take(TokenType.OPEN_CURLY);

        while(true) {
            InterfaceMemberAstNode? memberNode = InterfaceMemberAstNode.TryParse(parser);
            if (memberNode != null) {
                node.memberList.Add(memberNode);
            } else {
                break;
            }
        }

        parser.Take(TokenType.CLOSE_CURLY);

        return node;
    }
}
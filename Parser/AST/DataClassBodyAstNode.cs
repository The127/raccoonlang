namespace Raccoonlang.Parser.AST;

using Tokenizer;

public class DataClassBodyAstNode
{
    public List<DataClassMemberAstNode> memberList = new List<DataClassMemberAstNode>();

    public static DataClassBodyAstNode Parse(Parser parser)
    {
        DataClassBodyAstNode node = new DataClassBodyAstNode();

        parser.Take(TokenType.OPEN_CURLY);

        while(true) {
            DataClassMemberAstNode? memberNode = DataClassMemberAstNode.TryParse(parser);
            if (memberNode == null) break;
            node.memberList.Add(memberNode);
        }

        parser.Take(TokenType.CLOSE_CURLY);

        return node;
    }
}
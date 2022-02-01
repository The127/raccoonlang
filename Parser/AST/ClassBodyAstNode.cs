namespace Raccoonlang.Parser.AST;

using Tokenizer;

public class ClassBodyAstNode
{
    public List<ClassMemberAstNode> memberList = new List<ClassMemberAstNode>();

    public static ClassBodyAstNode Parse(Parser parser)
    {
        ClassBodyAstNode node = new ClassBodyAstNode();

        parser.Take(TokenType.OPEN_CURLY);

        while(true) {
            ClassMemberAstNode? memberNode = ClassMemberAstNode.TryParse(parser);
            if (memberNode == null) break;
            node.memberList.Add(memberNode);
        }

        return node;
    }
}

public class ClassMemberAstNode
{
    public static ClassMemberAstNode? TryParse(Parser parser)
    {
        ClassMemberAstNode node = new ClassMemberAstNode();

        return node;
    }
}
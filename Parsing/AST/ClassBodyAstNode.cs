namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class ClassBodyAstNode
{
    public List<ClassMemberAstNode> MemberList { get; set; } = new List<ClassMemberAstNode>();

    public static ClassBodyAstNode Parse(Parser parser)
    {
        ClassBodyAstNode node = new ClassBodyAstNode();

        parser.Take(TokenType.OpenCurly);
        while(parser.Peek().Type != TokenType.CloseCurly) {
            node.MemberList.Add(ClassMemberAstNode.Parse(parser));
        }
        
        return node;
    }
}

public class ClassMemberAstNode
{
    public static ClassMemberAstNode Parse(Parser parser)
    {
        ClassMemberAstNode node = new ClassMemberAstNode();
        //TODO
        return node;
    }
}
namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class GenericTypeConstraintAstNode 
{
    public List<GenericTypeConstraintsAstNode> constraintsList = new List<GenericTypeConstraintsAstNode>();

    public static GenericTypeConstraintAstNode? TryParse(Parser parser)
    {
        Token t = parser.Peek();
        if (t.Type != TokenType.WHERE) return null;

        parser.Skip();
        parser.Take(TokenType.COLON);

        GenericTypeConstraintAstNode node = new GenericTypeConstraintAstNode();

        node.constraintsList.Add(GenericTypeConstraintsAstNode.Parse(parser));

        while(true) {
            if (parser.Peek().Type != TokenType.COMMA) break;
            parser.Skip();
            node.constraintsList.Add(GenericTypeConstraintsAstNode.Parse(parser));
        }

        return node;

    }
}

public class GenericTypeConstraintsAstNode
{
    public List<GenericTypeConstraintAstNode> constraintList = new List<GenericTypeConstraintAstNode>();

    public static GenericTypeConstraintsAstNode Parse(Parser parser)
    {
        GenericTypeConstraintsAstNode node = new GenericTypeConstraintsAstNode();

        while(true) {
            GenericTypeConstraintAstNode? gNode = GenericTypeConstraintAstNode.TryParse(parser);
            if (gNode == null) break;

            node.constraintList.Add(gNode);
        }

        return node;
    }

    public override string ToString()
    {
        return "GenericTypeConstraintsAstNode{" +
               "genericTypeConstraintList=" + constraintList.ToArray() +
               "}";
    }
}
namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class GenericTypeConstraintsAstNode
{
    public List<GenericTypeConstraintAstNode> ConstraintList { get; set; } = new List<GenericTypeConstraintAstNode>();

    public static GenericTypeConstraintsAstNode Parse(Parser parser)
    {
        GenericTypeConstraintsAstNode node = new GenericTypeConstraintsAstNode();

        while (true)
        {
            GenericTypeConstraintAstNode? gNode = GenericTypeConstraintAstNode.TryParse(parser);
            if (gNode == null) return node;
            node.ConstraintList.Add(gNode);
        }
    }

    public override string ToString()
    {
        return "GenericTypeConstraintsAstNode{" +
               "genericTypeConstraintList=[" + string.Join(",", ConstraintList) + "]"+
               "}";
    }
}

public class GenericTypeConstraintAstNode
{
    public Token Identifier { get; set; }
    public List<GenericConstraintsAstNode> ConstraintsList { get; set; } = new();

    public static GenericTypeConstraintAstNode? TryParse(Parser parser)
    {
        GenericTypeConstraintAstNode node = new GenericTypeConstraintAstNode();

        if (parser.Peek().Type != TokenType.Where) return null;
        parser.Take(TokenType.Where);
        node.Identifier = parser.Take(TokenType.Identifier);
        parser.Take(TokenType.Colon);

        node.ConstraintsList.Add(GenericConstraintsAstNode.Parse(parser));

        while (parser.Peek().Type == TokenType.Comma)
        {
            parser.Take(TokenType.Comma);
            node.ConstraintsList.Add(GenericConstraintsAstNode.Parse(parser));
        }

        return node;
    }

    public override string ToString() => $"GenericTypeConstraintAstNode{{Identifier={Identifier}, [{string.Join(",", ConstraintsList)}]}}";
}

public class GenericConstraintsAstNode
{
    public IGenericConstraintsAstNode? GenericConstraint { get; set; }

    public static GenericConstraintsAstNode Parse(Parser parser)
    {
        GenericConstraintsAstNode node = new();
        node.GenericConstraint = NewConstraintAstNode.TryParse(parser);
        if (node.GenericConstraint != null) return node;

        node.GenericConstraint = ExtendsConstraintAstNode.TryParse(parser);
        if (node.GenericConstraint != null) return node;

        throw new System.Exception("UwU you fuwuked uwup.");
    }

    public override string ToString() => $"GenericConstraintsAstNode{{GenericConstraint={GenericConstraint}}}";
}

public interface IGenericConstraintsAstNode
{
    
}

public class ExtendsConstraintAstNode : IGenericConstraintsAstNode
{
    public FqtnAstNode Fqtn { get; set; }

    public static IGenericConstraintsAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Identifier) return null;
        ExtendsConstraintAstNode node = new();
        node.Fqtn = FqtnAstNode.Parse(parser);
        return node;
    }

    public override string ToString() => $"ExtendsConstraintAstNode{{Fqtn={Fqtn}}}";
}

public class NewConstraintAstNode : IGenericConstraintsAstNode
{
    public NewConstraintParametersAstNode Parameters { get; set; }
    
    public static IGenericConstraintsAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.New) return null;
        NewConstraintAstNode node = new();
        node.Parameters = NewConstraintParametersAstNode.Parse(parser);
        return node;
    }

    public override string ToString() => $"NewConstraintAstNode{{Parameters={Parameters}}}";
}

public class NewConstraintParametersAstNode
{
    public List<FqtnAstNode> Parameters { get; set; } = new();

    public static NewConstraintParametersAstNode Parse(Parser parser)
    {
        parser.Take(TokenType.OpenParen);

        NewConstraintParametersAstNode node = new();
        node.Parameters.Add(FqtnAstNode.Parse(parser));
        while (parser.Peek().Type == TokenType.Comma)
        {
            parser.Take(TokenType.Comma);
            node.Parameters.Add(FqtnAstNode.Parse(parser));
        }
        
        parser.Take(TokenType.CloseParen);
        return node;
    }

    public override string ToString() => $"NewConstraintParametersAstNode{{Parameters=[{string.Join(",", Parameters)}]}}";
}
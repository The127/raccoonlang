using Raccoonlang.Tokenizing;

namespace Raccoonlang.Parsing.AST;

public class PropertyMemberDeclarationAstNode
{
    public ModifiersAstNode Modifiers { get; set; }
    public FqtnAstNode Type { get; set; }
    public Token Name { get; set; }
    public IPropertyDeclaration Declaration { get; set; }

    public static PropertyMemberDeclarationAstNode? TryParse(Parser parser)
    {
        PropertyMemberDeclarationAstNode node = new();
        var parserState = parser.ShelfState();
        node.Modifiers = ModifiersAstNode.Parse(parser);
        
        var fqtnAstNode = FqtnAstNode.TryParse(parser);
        if (fqtnAstNode == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Type = fqtnAstNode;

        if (parser.Peek().Type != TokenType.Identifier)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Name = parser.Take(TokenType.Identifier);

        IPropertyDeclaration? declaration = FullPropertyDeclarationAstNode.TryParse(parser);
        if (declaration == null) declaration = LambdaPropertyDeclarationAstNode.TryParse(parser);
        if (declaration == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Declaration = declaration;
        
        return node;
    }
}

public interface IPropertyDeclaration
{
    
}

public class FullPropertyDeclarationAstNode : IPropertyDeclaration
{
    public PropertyGetterAstNode? Getter { get; set; }
    public PropertySetterAstNode? Setter { get; set; }
    public MemberInitializationExpressionAstNode? InitExpression { get; set; }
    
    public static FullPropertyDeclarationAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        if (parser.Peek().Type != TokenType.OpenCurly) return null;
        parser.Take(TokenType.OpenCurly);

        FullPropertyDeclarationAstNode node = new();

        node.Getter = PropertyGetterAstNode.TryParse(parser);
        node.Setter = PropertySetterAstNode.TryParse(parser);

        if (node.Getter == null && node.Setter == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        
        parser.Take(TokenType.CloseCurly);

        if (parser.Peek().Type == TokenType.Equals)
        {
            parser.Take(TokenType.Equals);
            node.InitExpression = MemberInitializationExpressionAstNode.Parse(parser);
            parser.Take(TokenType.Semicolon);
        }
        
        return node;
    }
}

public class LambdaPropertyDeclarationAstNode : IPropertyDeclaration
{
    public ExpressionAstNode Expression { get; set; }
    public static LambdaPropertyDeclarationAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.LambdaArrow) return null;
        parser.Take(TokenType.LambdaArrow);
        LambdaPropertyDeclarationAstNode node = new();
        node.Expression = ExpressionAstNode.Parse(parser);
        parser.Take(TokenType.Semicolon);
        return node;
    }
}

public class PropertyGetterAstNode
{
    public IGetter Getter { get; set; }
    public static PropertyGetterAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Get) return null;
        parser.Take(TokenType.Get);
        PropertyGetterAstNode node = new();
        IGetter? getter = FullGetterAstNode.TryParse(parser);
        if(getter == null) getter = LambdaGetterAstNode.TryParse(parser);
        if (getter == null) getter = new AutoGetter();
        node.Getter = getter;
        return node;
    }
}

public interface IGetter
{
    
}

public class AutoGetter : IGetter
{
}

public class FullGetterAstNode : IGetter
{
    public List<StatementAstNode> Statements { get; set; }
    
    public static FullGetterAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.OpenCurly) return null;
        parser.Take(TokenType.OpenCurly);
        
        FullGetterAstNode node = new();
        while (parser.Peek().Type != TokenType.CloseCurly)
        {
            node.Statements.Add(StatementAstNode.Parse(parser));
        }
        parser.Take(TokenType.CloseCurly);
        return node;
    }
}

public class LambdaGetterAstNode : IGetter
{
    public ExpressionAstNode Expression { get; set; }
    
    public static LambdaGetterAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.LambdaArrow) return null;
        parser.Take(TokenType.LambdaArrow);
        
        LambdaGetterAstNode node = new();
        node.Expression = ExpressionAstNode.Parse(parser);
        return node;
    }
}

public class PropertySetterAstNode
{
    public ISetter Setter { get; set; }
    
    public static PropertySetterAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Set) return null;
        parser.Take(TokenType.Set);
        PropertySetterAstNode node = new();
        ISetter? setter = FullSetterAstNode.TryParse(parser);
        if(setter == null) setter = LambdaSetterAstNode.TryParse(parser);
        if (setter == null) node.Setter = new AutoSetter();
        node.Setter = setter;
        return node;
    }
}

public interface ISetter
{
    
}

public class AutoSetter : ISetter
{
    
}

public class FullSetterAstNode : ISetter
{
    public List<StatementAstNode> Statements { get; set; }
    
    public static FullSetterAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.OpenCurly) return null;
        parser.Take(TokenType.OpenCurly);
        
        FullSetterAstNode node = new();
        while (parser.Peek().Type != TokenType.CloseCurly)
        {
            node.Statements.Add(StatementAstNode.Parse(parser));
        }
        parser.Take(TokenType.CloseCurly);
        return node;
    }
}

public class LambdaSetterAstNode : ISetter
{
    public ExpressionAstNode Expression { get; set; }
    
    public static LambdaSetterAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.LambdaArrow) return null;
        parser.Take(TokenType.LambdaArrow);
        
        LambdaSetterAstNode node = new();
        node.Expression = ExpressionAstNode.Parse(parser);
        return node;
    }
}
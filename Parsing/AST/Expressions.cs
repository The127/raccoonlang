using Raccoonlang.Tokenizing;

namespace Raccoonlang.Parsing.AST;

public class ExpressionAstNode
{
    public IExpression Expression { get; set; }

    public ExpressionAstNode(IExpression expression)
    {
        Expression = expression;
    }
    
    public static ExpressionAstNode Parse(Parser parser)
    {
        var expression = TryParse(parser);
        if (expression == null) throw new System.Exception("fucky wucky happened");
        return expression;
    }

    public static ExpressionAstNode? TryParse(Parser parser)
    {
        IExpression? expression = PreExpressionAstNode.TryParse(parser);
        if (expression != null) return new ExpressionAstNode(expression);
        
        expression = PrimaryExpressionAstNode.TryParse(parser);
        if (expression != null) return new ExpressionAstNode(expression);
        
        expression = ParExpressionAstNode.TryParse(parser);
        if (expression != null) return new ExpressionAstNode(expression);
        
        expression = CastExpressionAstNode.TryParse(parser);
        if (expression != null) return new ExpressionAstNode(expression);
        
        expression = ConstantExpressionAstNode.TryParse(parser);
        if (expression != null) return new ExpressionAstNode(expression);
        
        expression = CtorCallExpressionAstNode.TryParse(parser);
        if (expression != null) return new ExpressionAstNode(expression);
        
        
        expression = IdentifierExpressionAstNode.TryParse(parser);
        if (expression != null) return new ExpressionAstNode(expression);
        
        //
        // expression = CallExpressionAstNode.TryParse(parser);
        // if (expression != null) return new ExpressionAstNode(expression);
        //
        // expression = PostExpressionAstNode.TryParse(parser);
        // if (expression != null) return new ExpressionAstNode(expression);
        
        return null;
    }
}

public interface IExpression
{
    
}

public class PostExpressionAstNode : IExpression
{
    public ExpressionAstNode Expression { get; set; }
    public Token Operation { get; set; }

    public static PostExpressionAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        PostExpressionAstNode node = new();

        var expression = ExpressionAstNode.TryParse(parser);
        if (expression == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Expression = expression;

        if (parser.Peek().Type != TokenType.PlusPlus && parser.Peek().Type != TokenType.MinusMinus)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Operation = parser.Take();
        
        return node;
    }
}

public class CallExpressionAstNode : IExpression
{
    public ExpressionAstNode Expression { get; set; }
    public ExpressionListAstNode? Parameters { get; set; }

    public static CallExpressionAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        CallExpressionAstNode node = new();

        var expression = ExpressionAstNode.TryParse(parser);
        if (expression == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Expression = expression;

        if (parser.Peek().Type != TokenType.OpenParen)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.OpenParen);

        node.Parameters = ExpressionListAstNode.TryParse(parser);
        
        if (parser.Peek().Type != TokenType.CloseParen)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.CloseParen);
        
        return node;
    }
}

public class IdentifierExpressionAstNode : IExpression
{
    public Token Identifier { get; set; }

    public static IdentifierExpressionAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Identifier) return null;
        return new IdentifierExpressionAstNode()
        {
            Identifier = parser.Take(TokenType.Identifier),
        };
    }
}

public class CtorCallExpressionAstNode : IExpression
{
    public FqtnAstNode? FqtnAstNode { get; set; }
    public ExpressionListAstNode Parameters { get; set; }
    
    public static CtorCallExpressionAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        CtorCallExpressionAstNode node = new();

        node.FqtnAstNode = FqtnAstNode.TryParse(parser);

        if (parser.Peek().Type != TokenType.New)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.New);
        
        node.Parameters = ExpressionListAstNode.Parse(parser);

        return node;
    }
}

public class PreExpressionAstNode : IExpression
{
    public Token Operation { get; set; }
    public ExpressionAstNode Expression { get; set; }

    public static PreExpressionAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        var token = parser.Peek();
        if (!new[] { TokenType.PlusPlus, TokenType.MinusMinus }.Contains(token.Type)) return null;
        
        PreExpressionAstNode node = new();
        node.Operation = parser.Take(token.Type);
        
        var expression = ExpressionAstNode.TryParse(parser);
        if (expression == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Expression = expression;
        
        return node;
    }
}

public class PrimaryExpressionAstNode : IExpression
{
    public Token Token { get; set; }

    public static PrimaryExpressionAstNode? TryParse(Parser parser)
    {
        var token = parser.Peek();
        if (!new[] { TokenType.This, TokenType.Base }.Contains(token.Type)) return null;
        PrimaryExpressionAstNode node = new();
        node.Token = parser.Take(token.Type);
        return node;
    }
}

public class ParExpressionAstNode : IExpression
{
    public ExpressionAstNode Expression { get; set; }

    public static ParExpressionAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        if (parser.Peek().Type != TokenType.OpenParen) return null;
        parser.Take(TokenType.OpenParen);

        ParExpressionAstNode node = new();
        
        var expression = ExpressionAstNode.TryParse(parser);
        if (expression == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Expression = expression;
        
        if (parser.Peek().Type != TokenType.CloseParen) return null;
        parser.Take(TokenType.CloseParen);
        
        return node;
    }
}

public class CastExpressionAstNode : IExpression
{
    public FqtnAstNode Type { get; set; }
    public ExpressionAstNode Value { get; set; }

    public static CastExpressionAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Cast) return null;
        parser.Take(TokenType.Cast);
        
        CastExpressionAstNode node = new();
        
        parser.Take(TokenType.OpLt);
        node.Type = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.OpGt);
        
        parser.Take(TokenType.OpenParen);
        node.Value = ExpressionAstNode.Parse(parser);
        parser.Take(TokenType.CloseParen);
        
        return node;
    }
}

public class ConstantExpressionAstNode : IExpression
{
    public ILiteral Literal { get; set; }
    
    public ConstantExpressionAstNode(ILiteral literal)
    {
        Literal = literal;
    }
    
    public static ConstantExpressionAstNode Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception("oh oh!");
        return node;
    }

    public static ConstantExpressionAstNode? TryParse(Parser parser)
    {
        ILiteral? literal = StringLiteral.TryParse(parser);
        if (literal != null) return new ConstantExpressionAstNode(literal);
        
        literal = BooleanLiteral.TryParse(parser);
        if (literal != null) return new ConstantExpressionAstNode(literal);
        
        literal = NumberLiteral.TryParse(parser);
        if (literal != null) return new ConstantExpressionAstNode(literal);
        
        return null;
    }
}

public interface ILiteral
{
    
}

public class StringLiteral : ILiteral
{
    public Token Value { get; set; }

    public static StringLiteral? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.StringLiteral) return null;
        return new StringLiteral()
        {
            Value = parser.Take(TokenType.StringLiteral)
        };
    }
}

public class BooleanLiteral : ILiteral
{
    public Token Value { get; set; }

    public static BooleanLiteral? TryParse(Parser parser)
    {
        var token = parser.Peek();
        if (!new[]{TokenType.True, TokenType.False}.Contains(token.Type)) return null;
        return new BooleanLiteral()
        {
            Value = parser.Take(token.Type),
        };
    }
}

public class NumberLiteral : ILiteral
{
    public Token Value { get; set; }

    public static NumberLiteral? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.NumberLiteral) return null;
        return new NumberLiteral()
        {
            Value = parser.Take(TokenType.NumberLiteral)
        };
    }
}

public class ExpressionListAstNode : IExpression
{
    public List<ExpressionAstNode> Expressions { get; set; } = new();
    
    public static ExpressionListAstNode Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception("um, no!");
        return node;
    }

    public static ExpressionListAstNode? TryParse(Parser parser)
    {
        ExpressionListAstNode node = new();
        var parserState = parser.ShelfState();

        if (parser.Peek().Type != TokenType.OpenParen) return null;
        parser.Take(TokenType.OpenParen);

        var expression = ExpressionAstNode.TryParse(parser);
        if (expression == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Expressions.Add(expression);

        while (parser.Peek().Type == TokenType.Comma)
        {
            parser.Take(TokenType.Comma);
            expression = ExpressionAstNode.TryParse(parser);
            if (expression == null)
            {
                parser.RestoreState(parserState);
                return null;
            }
            node.Expressions.Add(expression);
        }

        if (parser.Peek().Type != TokenType.CloseParen)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.CloseParen);
        
        return null;
    }
}
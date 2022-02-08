using Raccoonlang.Tokenizing;
using Raccoonlang.Utils;

namespace Raccoonlang.Parsing.AST;

public class ExpressionAstNode
{
    public AddExpression Expression { get; set; }

    public static ExpressionAstNode Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception(parser.Peek().AutoToString());
        return node;
    }

    public static ExpressionAstNode? TryParse(Parser parser)
    {
        var addExpression = AddExpression.TryParse(parser);
        if (addExpression == null) return null;
        return new ExpressionAstNode() { Expression = addExpression };
    }
}

public class AddExpression
{
    public MultExpression Start { get; set; }
    public List<Token> Ops { get; set; } = new();
    public List<MultExpression> Expressions { get; set; } = new();

    public static AddExpression? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        AddExpression node = new();

        var expression = MultExpression.TryParse(parser);
        if (expression == null) return null;
        node.Start = expression;

        while (new[] { TokenType.OpPlus, TokenType.OpMinus }.Contains(parser.Peek().Type))
        {
            node.Ops.Add(parser.Take());
            expression = MultExpression.TryParse(parser);
            if (expression == null)
            {
                parser.RestoreState(parserState);
                return null;
            }

            node.Expressions.Add(expression);
        }

        return node;
    }
}

public class MultExpression
{
    public TermAstNode Start { get; set; }
    public List<Token> Ops { get; set; } = new();
    public List<TermAstNode> Terms { get; set; } = new();

    public static MultExpression? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        MultExpression node = new();

        var term = TermAstNode.TryParse(parser);
        if (term == null) return null;
        node.Start = term;

        while (new[] { TokenType.OpTimes, TokenType.OpDivision, TokenType.OpModulo }.Contains(parser.Peek().Type))
        {
            node.Ops.Add(parser.Take());
            term = TermAstNode.TryParse(parser);
            if (term == null)
            {
                parser.RestoreState(parserState);
                return null;
            }

            node.Terms.Add(term);
        }

        return node;
    }
}

public class TermAstNode
{
    public ITerm Expression { get; set; }

    public TermAstNode(ITerm expression)
    {
        Expression = expression;
    }

    public static TermAstNode Parse(Parser parser)
    {
        var expression = TryParse(parser);
        if (expression == null) throw new System.Exception("fucky wucky happened");
        return expression;
    }

    public static TermAstNode? TryParse(Parser parser)
    {
        ITerm? expression = PreTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        expression = PrimaryTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        expression = ParTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        expression = CastTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        expression = ConstantTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        expression = CtorCallTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        expression = CallTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        expression = FqtnTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        expression = IdentifierTermAstNode.TryParse(parser);
        if (expression != null) return new TermAstNode(expression);

        return null;
    }
}

public interface ITerm
{
}

public class PostTermAstNode
{
    public TermAstNode Expression { get; set; }
    public Token Operation { get; set; }

    public static PostTermAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        PostTermAstNode node = new();

        var expression = TermAstNode.TryParse(parser);
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

public class DotTermAstNode : ITerm
{
    public TermAstNode Expression { get; set; }

    public static DotTermAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Dot) return null;
        return new DotTermAstNode { Expression = TermAstNode.Parse(parser) };
    }
}

public class CallTermAstNode : ITerm
{
    public FqtnAstNode Name { get; set; }
    public ExpressionListAstNode Parameters { get; set; }

    public static CallTermAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        CallTermAstNode node = new();

        var name = FqtnAstNode.TryParse(parser);
        if (name == null)
        {
            parser.RestoreState(parserState);
            return null;
        }

        node.Name = name;

        var parameters = ExpressionListAstNode.TryParse(parser);
        if (parameters == null)
        {
            parser.RestoreState(parserState);
            return null;
        }

        node.Parameters = parameters;

        return node;
    }
}

public class FqtnTermAstNode : ITerm
{
    public FqtnAstNode FqtnAstNode { get; set; }

    public static FqtnTermAstNode? TryParse(Parser parser)
    {
        var fqtn = AST.FqtnAstNode.TryParse(parser);
        if (fqtn == null) return null;
        return new FqtnTermAstNode() { FqtnAstNode = fqtn };
    }
}

public class IdentifierTermAstNode : ITerm
{
    public Token Identifier { get; set; }

    public static IdentifierTermAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Identifier) return null;
        return new IdentifierTermAstNode()
        {
            Identifier = parser.Take(TokenType.Identifier),
        };
    }
}

public class CtorCallTermAstNode : ITerm
{
    public FqtnAstNode? FqtnAstNode { get; set; }
    public ExpressionListAstNode Parameters { get; set; }

    public static CtorCallTermAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        CtorCallTermAstNode node = new();

        node.FqtnAstNode = FqtnAstNode.TryParse(parser);

        if (parser.Peek().Type != TokenType.ColonColon)
        {
            parser.RestoreState(parserState);
            return null;
        }

        parser.Take(TokenType.ColonColon);

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

public class PreTermAstNode : ITerm
{
    public Token Operation { get; set; }
    public ExpressionAstNode Expression { get; set; }

    public static PreTermAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        var token = parser.Peek();
        if (!new[] { TokenType.PlusPlus, TokenType.MinusMinus }.Contains(token.Type)) return null;

        PreTermAstNode node = new();
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

public class PrimaryTermAstNode : ITerm
{
    public Token Token { get; set; }

    public static PrimaryTermAstNode? TryParse(Parser parser)
    {
        var token = parser.Peek();
        if (!new[] { TokenType.This, TokenType.Base }.Contains(token.Type)) return null;
        PrimaryTermAstNode node = new();
        node.Token = parser.Take(token.Type);
        return node;
    }
}

public class ParTermAstNode : ITerm
{
    public ExpressionAstNode Expression { get; set; }

    public static ParTermAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        if (parser.Peek().Type != TokenType.OpenParen) return null;
        parser.Take(TokenType.OpenParen);

        ParTermAstNode node = new();

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

public class CastTermAstNode : ITerm
{
    public FqtnAstNode Type { get; set; }
    public ExpressionAstNode Value { get; set; }

    public static CastTermAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Cast) return null;
        parser.Take(TokenType.Cast);

        CastTermAstNode node = new();

        parser.Take(TokenType.OpLt);
        node.Type = FqtnAstNode.Parse(parser);
        parser.Take(TokenType.OpGt);

        parser.Take(TokenType.OpenParen);
        node.Value = ExpressionAstNode.Parse(parser);
        parser.Take(TokenType.CloseParen);

        return node;
    }
}

public class ConstantTermAstNode : ITerm
{
    public ILiteral Literal { get; set; }

    public ConstantTermAstNode(ILiteral literal)
    {
        Literal = literal;
    }

    public static ConstantTermAstNode Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception("oh oh!");
        return node;
    }

    public static ConstantTermAstNode? TryParse(Parser parser)
    {
        ILiteral? literal = StringLiteral.TryParse(parser);
        if (literal != null) return new ConstantTermAstNode(literal);

        literal = BooleanLiteral.TryParse(parser);
        if (literal != null) return new ConstantTermAstNode(literal);

        literal = NumberLiteral.TryParse(parser);
        if (literal != null) return new ConstantTermAstNode(literal);

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
        if (!new[] { TokenType.True, TokenType.False }.Contains(token.Type)) return null;
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

public class ExpressionListAstNode : ITerm
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
        if (expression != null)
        {
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
        }

        if (parser.Peek().Type != TokenType.CloseParen)
        {
            parser.RestoreState(parserState);
            return null;
        }

        parser.Take(TokenType.CloseParen);
        return node;
    }
}
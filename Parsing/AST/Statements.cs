using System.Diagnostics.CodeAnalysis;
using Raccoonlang.Tokenizing;
using Raccoonlang.Utils;

namespace Raccoonlang.Parsing.AST;

public class StatementAstNode
{
    public static IStatement Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception("we done fucked up!" + parser.Peek().AutoToString());
        return node;
    }

    public static IStatement? TryParse(Parser parser)
    {
        IStatement? statement = LoopStatementAstNode.TryParse(parser);
        if (statement != null) return statement;

        statement = IfStatementAstNode.TryParse(parser);
        if (statement != null) return statement;

        statement = SwitchStatementAstNode.TryParse(parser);
        if (statement != null) return statement;

        statement = ReturnStatementAstNode.TryParse(parser);
        if (statement != null) return statement;

        statement = BreakStatementAstNode.TryParse(parser);
        if (statement != null) return statement;

        statement = ContinueStatementAstNode.TryParse(parser);
        if (statement != null) return statement;

        statement = LocalVariableAssignmentStatement.TryParse(parser);
        if (statement != null) return statement;

        statement = AssignmentStatementAstNode.TryParse(parser);
        if (statement != null) return statement;

        statement = ExpressionStatementAstNode.TryParse(parser);
        if (statement != null) return statement;

        return null;
    }
}

public interface IStatement
{
    
}

public class LoopStatementAstNode : IStatement
{
    public TermAstNode? Expression { get; set; }
    public FunctionBodyAstNode Body { get; set; }

    public static LoopStatementAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Loop) return null;
        parser.Take(TokenType.Loop);

        LoopStatementAstNode node = new();
        if (parser.Peek().Type != TokenType.OpenCurly && parser.Peek().Type != TokenType.LambdaArrow)
        {
            node.Expression = TermAstNode.Parse(parser);
        }
        node.Body = FunctionBodyAstNode.Parse(parser);
        return node;
    }
}

public class IfStatementAstNode : IStatement
{
    public TermAstNode Condition { get; set; }
    public FunctionBodyAstNode Body { get; set; }
    public List<ElifStatementAstNode> Elifs { get; set; } = new();
    public ElseStatementAstNode? Else { get; set; }
    
    public static IfStatementAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.If) return null;
        parser.Take(TokenType.If);

        IfStatementAstNode node = new();
        node.Condition = TermAstNode.Parse(parser);
        while (true)
        {
            var elif = ElifStatementAstNode.TryParse(parser);
            if (elif == null) break;
            node.Elifs.Add(elif);
        }

        var @else = ElseStatementAstNode.TryParse(parser);
        if (@else != null) node.Else = @else; 
        
        return node;
    }
}
public class ElifStatementAstNode : IStatement
{
    public TermAstNode Condition { get; set; }
    public FunctionBodyAstNode Body { get; set; }

    public static ElifStatementAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Elif) return null;
        parser.Take(TokenType.Elif);

        ElifStatementAstNode node = new();
        node.Condition = TermAstNode.Parse(parser);
        node.Body = FunctionBodyAstNode.Parse(parser);
        return node;
    }
}
public class ElseStatementAstNode : IStatement
{
    public FunctionBodyAstNode Body { get; set; }

    public static ElseStatementAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Else) return null;
        parser.Take(TokenType.Else);
        ElseStatementAstNode node = new();
        node.Body = FunctionBodyAstNode.Parse(parser);
        return node;
    }
}

public class SwitchStatementAstNode : IStatement
{
    public TermAstNode Expression { get; set; }
    public List<SwitchNodeAstNode> SwitchNodes { get; set; } = new();
    public DefaultSwitchNodeAstNode? DefaultNode { get; set; }
    
    public static SwitchStatementAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Switch) return null;
        parser.Take(TokenType.Switch);

        SwitchStatementAstNode node = new();
        node.Expression = TermAstNode.Parse(parser);
        parser.Take(TokenType.OpenCurly);

        while (true)
        {
            var switchNode = SwitchNodeAstNode.TryParse(parser);
            if (switchNode == null) break;
            node.SwitchNodes.Add(switchNode);
        }

        var defaultNode = DefaultSwitchNodeAstNode.TryParse(parser);
        if (defaultNode != null) node.DefaultNode = defaultNode;
        
        parser.Take(TokenType.CloseCurly);
        return node;
    }
}

public class SwitchNodeAstNode : IStatement
{
    public ConstantTermAstNode Constant { get; set; }
    public FunctionBodyAstNode Body { get; set; }
    
    public static SwitchNodeAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Case) return null;
        parser.Take(TokenType.Case);

        SwitchNodeAstNode node = new();
        node.Constant = ConstantTermAstNode.Parse(parser);
        node.Body = FunctionBodyAstNode.Parse(parser);
        return node;
    }
}

public class DefaultSwitchNodeAstNode : IStatement
{
    public FunctionBodyAstNode Body { get; set; }
    
    public static DefaultSwitchNodeAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Default) return null;
        parser.Take(TokenType.Default);

        DefaultSwitchNodeAstNode node = new();
        node.Body = FunctionBodyAstNode.Parse(parser);
        return node;
    }
}

public class ReturnStatementAstNode : IStatement
{
    public TermAstNode? ReturnValue { get; set; }

    public static ReturnStatementAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Return) return null;
        parser.Take(TokenType.Return);

        ReturnStatementAstNode node = new();
        node.ReturnValue = TermAstNode.TryParse(parser);
        parser.Take(TokenType.Semicolon);
        return node;
    }
}

public class BreakStatementAstNode : IStatement
{
    public static BreakStatementAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Break) return null;
        parser.Take(TokenType.Break);
        parser.Take(TokenType.Semicolon);
        return new BreakStatementAstNode();
    }
}

public class ContinueStatementAstNode : IStatement
{
    public static ContinueStatementAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Continue) return null;
        parser.Take(TokenType.Continue);
        parser.Take(TokenType.Semicolon);
        return new ContinueStatementAstNode();
    }
}

public class LocalVariableAssignmentStatement : IStatement
{
    public FqtnAstNode Type { get; set; }
    public Token Name { get; set; }
    public TermAstNode? Value { get; set; }

    public static LocalVariableAssignmentStatement? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        LocalVariableAssignmentStatement node = new();

        var fqtnAstNode = FqtnAstNode.TryParse(parser);
        if (fqtnAstNode == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Type = fqtnAstNode;

        var name = parser.Peek();
        if (name.Type != TokenType.Identifier)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Name = name;

        if (parser.Peek().Type == TokenType.Equals)
        {
            parser.Take(TokenType.Equals);
            node.Value = TermAstNode.Parse(parser);
        }

        parser.Take(TokenType.Semicolon);
        return node;
    }
}

public class AssignmentStatementAstNode : IStatement
{
    public VariableNameTermAstNode Name { get; set; }
    public TermAstNode Value { get; set; }

    public static AssignmentStatementAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        AssignmentStatementAstNode node = new();
        
        var varName = VariableNameTermAstNode.TryParse(parser);
        if (varName == null) return null;
        node.Name = varName;

        if (parser.Peek().Type != TokenType.Equals)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.Dot);
        
        node.Value = TermAstNode.Parse(parser);
        parser.Take(TokenType.Semicolon);
        return node;
    }
}

public class ExpressionStatementAstNode : IStatement
{
    public TermAstNode Expression { get; set; }

    public static ExpressionStatementAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        ExpressionStatementAstNode node = new();

        var expression = TermAstNode.TryParse(parser);
        if (expression == null)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Expression = expression;

        if (parser.Peek().Type != TokenType.Semicolon)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.Semicolon);
        return node;
    }

    public static ExpressionStatementAstNode Parse(Parser parser)
    {
        var node = TryParse(parser);
        if (node == null) throw new System.Exception(parser.Peek().AutoToString());
        return node;
    }
}
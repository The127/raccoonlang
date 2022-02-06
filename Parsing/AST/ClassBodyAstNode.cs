using Raccoonlang.Utils;

namespace Raccoonlang.Parsing.AST;

using Tokenizing;

public class ClassBodyAstNode
{
    public List<IClassMember> MemberList { get; set; } = new();

    public static ClassBodyAstNode Parse(Parser parser)
    {
        ClassBodyAstNode node = new ClassBodyAstNode();

        parser.Take(TokenType.OpenCurly);
        while(true)
        {
            var member = ClassMemberAstNode.TryParse(parser);
            if (member == null) break;
            node.MemberList.Add(member);
        }
        parser.Take(TokenType.CloseCurly);
        
        return node;
    }

    public override string ToString() => $"ClassBodyAstNode{{MemberList=[{string.Join(",", MemberList)}]}}";
}

public class ClassMemberAstNode
{
    public static IClassMember? TryParse(Parser parser)
    {
        IClassMember? member = CtorDefinitionAstNode.TryParse(parser);
        if (member != null) return member;

        member = FunctionDefinitionClassMemberAstNode.TryParse(parser);
        if (member != null) return member;
        
        member = ConstMemberDeclarationClassMemberAstNode.TryParse(parser);
        if (member != null) return member;
        
        member = PropertyMemberDeclarationClassMemberAstNode.TryParse(parser);
        if (member != null) return member;
        
        member = MethodMemberDeclarationClassMemberAstNode.TryParse(parser);
        if (member != null) return member;

        return null;
    }
}

public interface IClassMember
{
    
}

public class CtorDefinitionAstNode : IClassMember
{
    public ModifiersAstNode Modifiers { get; set; }
    public FunctionParametersAstNode Parameters { get; set; }
    public OtherCtorCall? CtorCall { get; set; }
    public FunctionBodyAstNode? Body { get; set; }

    public static CtorDefinitionAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        CtorDefinitionAstNode node = new();
        
        node.Modifiers = ModifiersAstNode.Parse(parser);

        if (parser.Peek().Type != TokenType.New)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.New);

        node.Parameters = FunctionParametersAstNode.Parse(parser);
        node.CtorCall = OtherCtorCall.TryParse(parser);
        node.Body = FunctionBodyAstNode.TryParse(parser);
        if (node.Body == null) parser.Take(TokenType.Semicolon);
        
        return node;
    }
}

public class OtherCtorCall
{
    public Token CtorName { get; set; }
    public ExpressionListAstNode? Expressions { get; set; }

    public static OtherCtorCall? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        OtherCtorCall node = new();
        if (parser.Peek().Type != TokenType.Colon) return null;
        parser.Take(TokenType.Colon);

        if (parser.Peek().Type != TokenType.This && parser.Peek().Type != TokenType.Base)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.CtorName = parser.Take();
        
        node.Expressions = ExpressionListAstNode.TryParse(parser);
        return node;
    } 
}

public class FunctionDefinitionClassMemberAstNode : IClassMember
{
    public FunctionDefinitionAstNode Fn { get; set; }
    public static FunctionDefinitionClassMemberAstNode? TryParse(Parser parser)
    {
        var functionDefinitionAstNode = FunctionDefinitionAstNode.TryParse(parser);
        if (functionDefinitionAstNode == null) return null;
        FunctionDefinitionClassMemberAstNode node = new();
        node.Fn = functionDefinitionAstNode;
        return node;
    }
}

public class ConstMemberDeclarationClassMemberAstNode : IClassMember
{
    public ConstMemberDeclarationAstNode Const { get; set; }
    
    public static ConstMemberDeclarationClassMemberAstNode? TryParse(Parser parser)
    {
        var constMemberDeclarationAstNode = ConstMemberDeclarationAstNode.TryParse(parser);
        if (constMemberDeclarationAstNode == null) return null;
        ConstMemberDeclarationClassMemberAstNode node = new();
        node.Const = constMemberDeclarationAstNode;
        return node;
    }
}

public class PropertyMemberDeclarationClassMemberAstNode : IClassMember
{
    public PropertyMemberDeclarationAstNode Property { get; set; }
    public static PropertyMemberDeclarationClassMemberAstNode? TryParse(Parser parser)
    {
        var property = PropertyMemberDeclarationAstNode.TryParse(parser);
        if (property == null) return null;
        PropertyMemberDeclarationClassMemberAstNode node = new();
        node.Property = property;
        return node;
    }
}

public class MethodMemberDeclarationClassMemberAstNode : IClassMember
{
    public MethodMemberDeclarationAstNode Method { get; set; }
    public static MethodMemberDeclarationClassMemberAstNode? TryParse(Parser parser)
    {
        var method = MethodMemberDeclarationAstNode.TryParse(parser);
        if (method == null) return null;
        MethodMemberDeclarationClassMemberAstNode node = new();
        node.Method = method;
        return node;
    }
}
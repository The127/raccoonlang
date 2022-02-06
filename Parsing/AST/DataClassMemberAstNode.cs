namespace Raccoonlang.Parsing.AST;

public class DataClassMemberAstNode
{
    public static IDataClassMember? TryParse(Parser parser)
    {
        IDataClassMember? member = ConstMemberDeclarationDataClassMemberAstNode.TryParse(parser);
        if (member != null) return member;
        
        member = FunctionDeclarationDataClassMemberAstNode.TryParse(parser);
        if (member != null) return member;
        
        member = PropertyMemberDeclarationDataClassMemberAstNode.TryParse(parser);
        if (member != null) return member;
        
        member = MethodMemberDeclarationDataClassMemberAstNode.TryParse(parser);
        if (member != null) return member;

         return null;
    }
}

public interface IDataClassMember
{
    
}

public class ConstMemberDeclarationDataClassMemberAstNode : IDataClassMember {
    public ConstMemberDeclarationAstNode Const { get; set; }
    public static ConstMemberDeclarationDataClassMemberAstNode? TryParse(Parser parser)
    {
        var constMemberDeclarationAstNode = ConstMemberDeclarationAstNode.TryParse(parser);
        if (constMemberDeclarationAstNode == null) return null;
        ConstMemberDeclarationDataClassMemberAstNode node = new();
        node.Const = constMemberDeclarationAstNode;
        return node;
    }
}

public class FunctionDeclarationDataClassMemberAstNode : IDataClassMember {
    public FunctionDefinitionAstNode Fn { get; set; }
    public static FunctionDeclarationDataClassMemberAstNode? TryParse(Parser parser)
    {
        var functionDefinitionAstNode = FunctionDefinitionAstNode.TryParse(parser);
        if (functionDefinitionAstNode == null) return null;
        FunctionDeclarationDataClassMemberAstNode node = new();
        node.Fn = functionDefinitionAstNode;
        return node;
    }
}

public class PropertyMemberDeclarationDataClassMemberAstNode : IDataClassMember {
    public PropertyMemberDeclarationAstNode Property { get; set; }
    public static PropertyMemberDeclarationDataClassMemberAstNode? TryParse(Parser parser)
    {
        var property = PropertyMemberDeclarationAstNode.TryParse(parser);
        if (property == null) return null;
        PropertyMemberDeclarationDataClassMemberAstNode node = new();
        node.Property = property;
        return node;
    }
}

public class MethodMemberDeclarationDataClassMemberAstNode : IDataClassMember {
    public MethodMemberDeclarationAstNode Method { get; set; }
    public static MethodMemberDeclarationDataClassMemberAstNode? TryParse(Parser parser)
    {
        var method = MethodMemberDeclarationAstNode.TryParse(parser);
        if (method == null) return null;
        MethodMemberDeclarationDataClassMemberAstNode node = new();
        node.Method = method;
        return node;
    }
}
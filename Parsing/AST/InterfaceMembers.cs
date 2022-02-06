using Raccoonlang.Tokenizing;

namespace Raccoonlang.Parsing.AST;

public class InterfaceMemberAstNode
{
    public IInterfaceMember? Member { get; set; }

    public static InterfaceMemberAstNode Parse(Parser parser)
    {
        InterfaceMemberAstNode node = new InterfaceMemberAstNode();

        node.Member = InterfaceMethodDeclarationAstNode.TryParse(parser);
        if (node.Member != null) return node;

        node.Member = InterfaceFunctionDeclarationAstNode.TryParse(parser);
        if (node.Member != null) return node;

        node.Member = InterfacePropertyDeclarationAstNode.TryParse(parser);
        if (node.Member != null) return node;

        throw new System.Exception("fucked up");
    }

    public override string ToString() => $"InterfaceMemberAstNode{{\nMember={Member}}}";
}

public interface IInterfaceMember
{
    
}

public class InterfaceMethodDeclarationAstNode : IInterfaceMember
{
    public FqtnAstNode Type { get; set; }
    public Token Name { get; set; }
    public GenericTypesAstNode? GenericTypes { get; set; }
    public FunctionParametersAstNode Parameters { get; set; }
    public GenericTypeConstraintsAstNode GenericTypeConstraints { get; set; }
    
    public static InterfaceMethodDeclarationAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        
        InterfaceMethodDeclarationAstNode node = new();

        node.Type = FqtnAstNode.TryParse(parser)!;
        if (node.Type == null!) return null;

        if (parser.Peek().Type != TokenType.Identifier)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Name = parser.Take(TokenType.Identifier);
        
        node.GenericTypes = GenericTypesAstNode.TryParse(parser);
        
        
        node.Parameters = FunctionParametersAstNode.TryParse(parser)!;
        if (node.Parameters == null!)
        {
            parser.RestoreState(parserState);
            return null;
        }
        
        node.GenericTypeConstraints = GenericTypeConstraintsAstNode.Parse(parser);

        parser.Take(TokenType.Semicolon);
        return node;
    }
}

public class InterfaceFunctionDeclarationAstNode : IInterfaceMember
{
    public FqtnAstNode Type { get; set; }
    public Token Name { get; set; }
    public GenericTypesAstNode? GenericTypes { get; set; }
    public FunctionParametersAstNode Parameters { get; set; }
    public GenericTypeConstraintsAstNode GenericTypeConstraints { get; set; }
    
    public static InterfaceFunctionDeclarationAstNode? TryParse(Parser parser)
    {
        if (parser.Peek().Type != TokenType.Fn)
        {
            return null;
        }
        parser.Take(TokenType.Fn);
        
        InterfaceFunctionDeclarationAstNode node = new();
        node.Type = FqtnAstNode.Parse(parser);
        node.Name = parser.Take(TokenType.Identifier);
        node.GenericTypes = GenericTypesAstNode.TryParse(parser);
        node.Parameters = FunctionParametersAstNode.Parse(parser);
        node.GenericTypeConstraints = GenericTypeConstraintsAstNode.Parse(parser);

        parser.Take(TokenType.Semicolon);
        return node;
    }
}

public class InterfacePropertyDeclarationAstNode : IInterfaceMember
{
    public FqtnAstNode Type { get; set; }
    public Token Name { get; set; }
    public bool HasGet { get; set; }
    public bool HasSet { get; set; }
    
    public static InterfacePropertyDeclarationAstNode? TryParse(Parser parser)
    {
        var parserState = parser.ShelfState();
        InterfacePropertyDeclarationAstNode node = new();
        
        node.Type = FqtnAstNode.TryParse(parser)!;
        if (node.Type == null!) return null;
        
        if (parser.Peek().Type != TokenType.Identifier)
        {
            parser.RestoreState(parserState);
            return null;
        }
        node.Name = parser.Take(TokenType.Identifier);
        
        
        if (parser.Peek().Type != TokenType.OpenCurly)
        {
            parser.RestoreState(parserState);
            return null;
        }
        parser.Take(TokenType.OpenCurly);

        if (parser.Peek().Type == TokenType.Get)
        {
            node.HasGet = true;
            parser.Take(TokenType.Get);
        }

        if (parser.Peek().Type == TokenType.Set)
        {
            node.HasSet = true;
            parser.Take(TokenType.Set);
        }

        if (!node.HasGet && !node.HasSet)
        {
            throw new System.Exception("impossible! you fucked up");
        }
        
        parser.Take(TokenType.CloseCurly);
        
        return node;
    }
}
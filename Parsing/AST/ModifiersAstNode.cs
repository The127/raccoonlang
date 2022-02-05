namespace Raccoonlang.Parsing.AST;

using Tokenizing;
using Exception;

public class ModifiersAstNode {
    bool IsPublic { get; set; }
    bool IsPrivate { get; set; }
    bool IsProtected { get; set; }
    bool IsInternal { get; set; }

    public static ModifiersAstNode Parse(Parser parser)
    {
        ModifiersAstNode node = new ModifiersAstNode();

        bool isMod = true;

        while (isMod) {
            Token t = parser.Peek();

            switch(t.Type) {
                case TokenType.Public:
                    if(node.IsPublic) throw new DuplicateModifierException(t);
                    node.IsPublic = true;
                    break;
                case TokenType.Private:
                    if(node.IsPrivate) throw new DuplicateModifierException(t);
                    node.IsPrivate = true;
                    break;
                case TokenType.Protected:
                    if(node.IsProtected) throw new DuplicateModifierException(t);
                    node.IsProtected = true;
                    break;
                case TokenType.Internal:
                    if(node.IsInternal) throw new DuplicateModifierException(t);
                    node.IsInternal = true;
                    break;
                default:
                    isMod = false;
                    break;
            }

            if(isMod) parser.Skip();
        }

        return node;

    }

    public override string ToString()
    {
        return "ModifiersAstNode{" +
                "isPublic=" + IsPublic +
                ", isPrivate=" + IsPrivate +
                ", isProtected=" + IsProtected +
                ", isInternal=" + IsInternal +
                "}";
    }

}
namespace Raccoonlang.Parser.AST;

using Tokenizer;
using Exception;

public class ModifiersAstNode {
    bool isPublic;
    bool isPrivate;
    bool isProtected;
    bool isInternal;

    public static ModifiersAstNode Parse(Parser parser)
    {
        ModifiersAstNode node = new ModifiersAstNode();

        bool isMod = true;

        while (isMod) {
            Token t = parser.Peek();

            switch(t.Type) {
                case TokenType.PUBLIC:
                    if(node.isPublic) throw new DuplicateModifierException(t);
                    node.isPublic = true;
                    break;
                case TokenType.PRIVATE:
                    if(node.isPrivate) throw new DuplicateModifierException(t);
                    node.isPrivate = true;
                    break;
                case TokenType.PROTECTED:
                    if(node.isProtected) throw new DuplicateModifierException(t);
                    node.isProtected = true;
                    break;
                case TokenType.INTERNAL:
                    if(node.isInternal) throw new DuplicateModifierException(t);
                    node.isInternal = true;
                    break;
                default:
                    isMod = false;
                    break;
            }

            if(isMod) {
                parser.Take();
            }
        }

        return node;

    }

    public override string ToString()
    {
        return "ModifiersAstNode{" +
                "isPublic=" + isPublic +
                ", isPrivate=" + isPrivate +
                ", isProtected=" + isProtected +
                ", isInternal=" + isInternal +
                "}";
    }

}
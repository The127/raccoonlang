package raccoonlang.parser.ast;

import raccoonlang.parser.Parser;
import raccoonlang.tokenizer.Token;

public class ModifiersAstNode {
    public boolean isPublic;
    public boolean isPrivate;
    public boolean isProtected;
    public boolean isInternal;

    public static ModifiersAstNode parse(Parser parser) {
        ModifiersAstNode modifiersAstNode = new ModifiersAstNode();

        boolean wasModifier = true;
        while (wasModifier){
            Token token = parser.peek();
            switch (token.getTokenType()){
                case PUBLIC:
                    if(modifiersAstNode.isPublic) throw new RuntimeException("Duplicate modifier at: " + token);// TODO: custom exception
                    modifiersAstNode.isPublic = true;
                    break;
                case PRIVATE:
                    if(modifiersAstNode.isPrivate) throw new RuntimeException("Duplicate modifier at: " + token);// TODO: custom exception
                    modifiersAstNode.isPrivate = true;
                    break;
                case PROTECTED:
                    if(modifiersAstNode.isProtected) throw new RuntimeException("Duplicate modifier at: " + token);// TODO: custom exception
                    modifiersAstNode.isProtected = true;
                    break;
                case INTERNAL:
                    if(modifiersAstNode.isInternal) throw new RuntimeException("Duplicate modifier at: " + token);// TODO: custom exception
                    modifiersAstNode.isInternal = true;
                    break;
                default:
                    wasModifier = false;
            }
        }

        return modifiersAstNode;
    }

    @Override
    public String toString() {
        return "ModifiersAstNode{" +
                "isPublic=" + isPublic +
                ", isPrivate=" + isPrivate +
                ", isProtected=" + isProtected +
                ", isInternal=" + isInternal +
                '}';
    }
}

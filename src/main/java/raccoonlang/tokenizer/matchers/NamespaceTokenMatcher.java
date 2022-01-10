
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class NamespaceTokenMatcher extends ConstantTokenMatcherBase {
    public NamespaceTokenMatcher() {
        super("namespace", TokenType.NAMESPACE);
    }
}


package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class NamespaceTokenMatcher extends EqualsTokenMatcherBase {
    public NamespaceTokenMatcher() {
        super("namespace", TokenType.NAMESPACE);
    }
}

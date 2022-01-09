
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ImportlTokenMatcher extends EqualsTokenMatcherBase {
    public ImportlTokenMatcher() {
        super("import", TokenType.IMPORT);
    }
}

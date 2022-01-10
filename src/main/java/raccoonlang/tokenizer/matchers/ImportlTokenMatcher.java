
package raccoonlang.tokenizer.matchers;

import raccoonlang.tokenizer.TokenType;

public class ImportlTokenMatcher extends ConstantTokenMatcherBase {
    public ImportlTokenMatcher() {
        super("import", TokenType.IMPORT);
    }
}

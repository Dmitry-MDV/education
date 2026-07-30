// using System;

public class Program {

    public static void Main(string[] args) {
        Identifier.Clean("àḃç");
        Identifier.Clean("my   Id");
        Identifier.Clean("my\0Id");
        Identifier.Clean(string.Empty);
        Identifier.Clean("à-ḃç");
        Identifier.Clean("à-Ḃç");
        Identifier.Clean("abc-def-ghi");
        Identifier.Clean("My😀😀Finder😀");
        Identifier.Clean("1My2Finder3");
        Identifier.Clean("MyΟβιεγτFinder");
        Identifier.Clean("9 -abcĐ😀ω\0");
        Identifier.Clean("");
    }
}

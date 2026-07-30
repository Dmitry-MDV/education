using System;
using System.Text;

public static class Identifier {
    public static string Clean(string identifier) {
        Console.Write("\"{0}\"", identifier);
        if (identifier.Equals(String.Empty)) {
            return identifier;
        }
        // identifier = identifier.Replace(" ", "_");
        StringBuilder builder = new StringBuilder();
        foreach(char ch in identifier) {
            if (ch == ' ') {
                builder.Append("_");
            } else if (char.IsControl(ch)){
                builder.Append("CTRL");
            } else if (ch >= '\u03B1' && ch <= '\u03C9'){
            } else if (Char.IsLetter(ch)){
                builder.Append(ch);
            } else if (ch == '-'){
                builder.Append(ch);
            } else {
            }
        }
        identifier = builder.ToString();
        string[] subs = identifier.Split('-');
        for (int i = 1; i < subs.Length; ++i) {
            subs[i] = String.Concat(subs[i].Substring(0, 1).ToUpper(), subs[i].Substring(1));
        }
        identifier = String.Concat(subs);
        return identifier;
    }
}

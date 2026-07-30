using System.Text;

public static class Identifier {
    public static string Clean(string identifier) {
        Console.Write("\"{0}\"", identifier);
        if (identifier.Equals(String.Empty)) {
            Console.WriteLine("\t\"{0}\"", identifier);
            return identifier;
        }
        bool previousDash = false; // the previous character was a dash
        StringBuilder builder = new StringBuilder();
        foreach (char ch in identifier) {
            if (ch == ' ') {
                builder.Append("_");
            } else if (char.IsControl(ch)) {
                builder.Append("CTRL");
            } else if (ch == '-') {
                previousDash = true;
            } else if (ch >= 'α' && ch <= 'ω') {
            } else if (!Char.IsLetter(ch)) {
            } else if (previousDash) {
                builder.Append(Char.ToUpper(ch));
                previousDash = false;
            } else {
                builder.Append(ch);
            }
        }
        identifier = builder.ToString();
        Console.WriteLine("\t\"{0}\"", identifier);
        return identifier;
     // return builder.ToString();
    }
}

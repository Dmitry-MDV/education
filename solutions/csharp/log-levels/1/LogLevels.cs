static class LogLine {

    public static string Message(string logLine) => logLine.Substring(logLine.IndexOf(':') + 1).Trim();

    public static string LogLevel(string logLine) => logLine.Substring(logLine.IndexOf('[') + 1, logLine.IndexOf(']') - 1).Trim().ToLower();

    public static string Reformat(string logLine) => $"{LogLine.Message(logLine)} ({LogLine.LogLevel(logLine)})";

}

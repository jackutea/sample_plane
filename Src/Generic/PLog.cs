using System;

public static class PLog {

    public static void LogError(string msg) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    public static void LogWarning(string msg) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Console.ResetColor();
    }

    public static void Log(string msg) {
        Console.WriteLine(msg);
    }

}
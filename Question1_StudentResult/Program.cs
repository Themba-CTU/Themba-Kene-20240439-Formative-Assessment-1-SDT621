using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Title = "Student Result System";
        Console.ForegroundColor = ConsoleColor.Cyan;

        TypeWriterHeader("STUDENT RESULT INPUT");

        Console.ResetColor();
        Console.Write("\nEnter student name: ");
        string name = Console.ReadLine();

        int mark1 = GetValidMark("Enter mark for Subject 1: ");
        int mark2 = GetValidMark("Enter mark for Subject 2: ");
        int mark3 = GetValidMark("Enter mark for Subject 3: ");

        int total = mark1 + mark2 + mark3;
        double average = total / 3.0;

        string result = average >= 50 ? "PASS" : "FAIL";

        ShowLoading("Processing results");

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        TypeWriterHeader("STUDENT REPORT");

        Console.ResetColor();

        PrintCenteredLine($"Student Name : {name}");
        PrintCenteredLine($"Total Marks  : {total}");
        PrintCenteredLine($"Average      : {average:F1}");
        PrintCenteredResult("Result", result);
        PrintCenteredLine($"Issued At    : {DateTime.Now}");

        PrintDivider();

        Console.Write("\nPress any key to exit...");
        Console.ReadKey();
    }

    static int GetValidMark(string message)
    {
        int mark;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out mark) && mark >= 0 && mark <= 100)
            {
                return mark;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Enter a number between 0 and 100.");
            Console.ResetColor();
        }
    }

    // TYPEWRITER HEADER
    static void TypeWriterHeader(string text)
    {
        PrintDivider();

        int leftPadding = (Console.WindowWidth - text.Length) / 2;
        Console.SetCursorPosition(Math.Max(leftPadding, 0), Console.CursorTop);

        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }

        Console.WriteLine();
        PrintDivider();
    }

    // CENTERED TEXT
    static void PrintCenteredLine(string text)
    {
        int leftPadding = (Console.WindowWidth - text.Length) / 2;
        Console.SetCursorPosition(Math.Max(leftPadding, 0), Console.CursorTop);
        Console.WriteLine(text);
    }

    // COLORED RESULT LINE
    static void PrintCenteredResult(string label, string result)
    {
        string fullText = $"{label} : {result}";
        int leftPadding = (Console.WindowWidth - fullText.Length) / 2;

        Console.SetCursorPosition(Math.Max(leftPadding, 0), Console.CursorTop);

        Console.Write($"{label} : ");

        if (result == "PASS")
            Console.ForegroundColor = ConsoleColor.Green;
        else
            Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(result);

        Console.ResetColor();
    }

    // DIVIDER
    static void PrintDivider()
    {
        string line = new string('=', Console.WindowWidth - 1);
        Console.WriteLine(line);
    }

    // LOADING EFFECT
    static void ShowLoading(string message)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        for (int i = 0; i <= 20; i++)
        {
            Console.Clear();

            string dots = new string('.', i % 4);
            string bar = new string('#', i) + new string('-', 20 - i);

            PrintCenteredLine(message + dots);
            Console.WriteLine();
            PrintCenteredLine($"[{bar}] {i * 5}%");

            Thread.Sleep(80);
        }

        Console.ResetColor();
    }
}
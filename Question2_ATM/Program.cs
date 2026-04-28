using System;
using System.Threading;

class ATM
{
    static void Main()
    {
        Console.Title = "CTU ATM System";
        Console.ForegroundColor = ConsoleColor.Cyan;

        TypeWriterHeader("CTU SIMPLE ATM SYSTEM");

        Console.ResetColor();
        Console.Write("\nHi, what is your name? ");
        string name = Console.ReadLine();

        PrintCenteredLine($"Welcome {name}!");

        double balance = GetValidAmount("\nEnter account balance: ");
        double withdrawal = GetValidAmount("Enter withdrawal amount: ");

        ShowLoading("Processing transaction");

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        TypeWriterHeader("TRANSACTION RECEIPT");
        Console.ResetColor();

        if (withdrawal > balance)
        {
            PrintCenteredColored("Insufficient funds.", ConsoleColor.Red);
        }
        else
        {
            balance -= withdrawal;

            PrintCenteredColored("Withdrawal successful!", ConsoleColor.Green);
            PrintCenteredLine($"Updated Balance : {balance:F2}");
            PrintCenteredLine($"Transaction Time: {DateTime.Now}");
        }

        PrintDivider();

        Console.Write("\nPress any key to exit...");
        Console.ReadKey();
    }

    static double GetValidAmount(string message)
    {
        double amount;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out amount) && amount >= 0)
            {
                return amount;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Enter a positive number.");
            Console.ResetColor();
        }
    }

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

    static void PrintCenteredLine(string text)
    {
        int leftPadding = (Console.WindowWidth - text.Length) / 2;
        Console.SetCursorPosition(Math.Max(leftPadding, 0), Console.CursorTop);
        Console.WriteLine(text);
    }

    static void PrintCenteredColored(string text, ConsoleColor color)
    {
        int leftPadding = (Console.WindowWidth - text.Length) / 2;
        Console.SetCursorPosition(Math.Max(leftPadding, 0), Console.CursorTop);

        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    static void PrintDivider()
    {
        string line = new string('=', Console.WindowWidth - 1);
        Console.WriteLine(line);
    }

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
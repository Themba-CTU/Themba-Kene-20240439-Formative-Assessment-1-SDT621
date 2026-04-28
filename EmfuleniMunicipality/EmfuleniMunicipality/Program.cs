using System;
using System.Collections.Generic;
using System.Threading;
using EmfuleniMunicipality;

class Program
{
    static void Main()
    {
        Title();

        List<Resident> residents = new List<Resident>();
        List<ServiceRequest> requests = new List<ServiceRequest>();

        Console.Write("Enter number of residents: ");
        int residentCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < residentCount; i++)
        {
            Console.WriteLine($"\n--- Resident {i + 1} ---");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Account Number: ");
            string acc = Console.ReadLine();

            Console.Write("Monthly Usage: ");
            double usage = double.Parse(Console.ReadLine());

            residents.Add(new Resident(name, address, acc, usage));
        }

        Console.Write("\nEnter number of service requests: ");
        int requestCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < requestCount; i++)
        {
            Console.WriteLine($"\n--- Request {i + 1} ---");

            Console.Write("Select Resident (index): ");
            for (int j = 0; j < residents.Count; j++)
                Console.WriteLine($"{j + 1}. {residents[j].Name}");

            int resIndex = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Request Type: ");
            string type = Console.ReadLine();

            int priority = GetValidRange("Priority (1-5): ", 1, 5);
            int severity = GetValidRange("Severity (1-10): ", 1, 10);

            Console.Write("Estimated Hours: ");
            int hours = int.Parse(Console.ReadLine());

            requests.Add(new ServiceRequest(residents[resIndex], type, priority, severity, hours));
        }

        Loading();

        UtilitiesManager manager = new UtilitiesManager();
        manager.CalculateUrgency(requests);
        manager.ProcessRequests(requests);

        Console.WriteLine("\nSystem complete. Press any key...");
        Console.ReadKey();
    }

    static int GetValidRange(string msg, int min, int max)
    {
        int val;
        while (true)
        {
            Console.Write(msg);
            if (int.TryParse(Console.ReadLine(), out val) && val >= min && val <= max)
                return val;

            Console.WriteLine("Invalid input.");
        }
    }

    // UNIQUE STYLE (different from your previous apps)
    static void Title()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("############################################");
        TypeText(" EMFULENI MUNICIPALITY SERVICE SYSTEM ");
        Console.WriteLine("\n############################################\n");
        Console.ResetColor();
    }

    static void TypeText(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(20);
        }
    }

    static void Loading()
    {
        Console.Write("\nInitializing System");

        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(300);
            Console.Write(".");
        }

        Console.Clear();
    }
} 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmfuleniMunicipality
{
    public class UtilitiesManager
    {
        public void CalculateUrgency(List<ServiceRequest> requests)
        {
            foreach (var r in requests)
            {
                r.UrgencyScore = (r.PriorityLevel * 2) + (r.SeverityLevel * 3) + (100.0 / r.EstimatedHours);
            }
        }

        public void DisplayQueue(List<ServiceRequest> requests)
        {
            Console.WriteLine("\n===== SERVICE QUEUE =====\n");

            var sorted = requests.OrderByDescending(r => r.UrgencyScore).ToList();

            int index = 1;
            foreach (var r in sorted)
            {
                Console.WriteLine($"{index}. {r.RequestType} | {r.Resident.Name} | Urgency: {r.UrgencyScore:F2}");
                index++;
            }
        }

        public void ProcessRequests(List<ServiceRequest> requests)
        {
            List<ServiceRequest> processed = new List<ServiceRequest>();

            while (requests.Count > 0)
            {
                DisplayQueue(requests);

                Console.Write("\nSelect request number to process: ");
                int choice = int.Parse(Console.ReadLine()) - 1;

                var selected = requests.OrderByDescending(r => r.UrgencyScore).ToList()[choice];

                PrintReport(selected);

                processed.Add(selected);
                requests.Remove(selected);
            }

            ShowSummary(processed);
        }

        public void PrintReport(ServiceRequest r)
        {
            Console.WriteLine("\n===== PROCESSING REPORT =====");

            Console.WriteLine($"Resident: {r.Resident.Name}");
            Console.WriteLine($"Address: {r.Resident.Address}");
            Console.WriteLine($"Request: {r.RequestType}");
            Console.WriteLine($"Priority: {r.PriorityLevel}");
            Console.WriteLine($"Severity: {r.SeverityLevel}");
            Console.WriteLine($"Urgency Score: {r.UrgencyScore:F2}");
        }

        public void ShowSummary(List<ServiceRequest> processed)
        {
            Console.WriteLine("\n===== FINAL SUMMARY =====");

            foreach (var r in processed)
            {
                Console.WriteLine($"{r.RequestType} - {r.Resident.Name}");
            }

            var highest = processed.OrderByDescending(r => r.UrgencyScore).First();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHighest Urgency: {highest.RequestType} ({highest.UrgencyScore:F2})");
            Console.ResetColor();
        }
    }
}
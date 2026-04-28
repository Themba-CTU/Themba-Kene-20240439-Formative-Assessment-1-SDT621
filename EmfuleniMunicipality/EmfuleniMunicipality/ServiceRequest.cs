using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmfuleniMunicipality
{
    public class ServiceRequest
    {
        public Resident Resident { get; set; }
        public string RequestType { get; set; }
        public int PriorityLevel { get; set; } // 1-5
        public int SeverityLevel { get; set; } // 1-10
        public int EstimatedHours { get; set; }

        public double UrgencyScore { get; set; }

        public ServiceRequest(Resident resident, string type, int priority, int severity, int hours)
        {
            Resident = resident;
            RequestType = type;
            PriorityLevel = priority;
            SeverityLevel = severity;
            EstimatedHours = hours;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAffairsDigitalIdentityProcessor
{
    internal class CitizenProfile
    {
        
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public int Age { get; set; }
        public string CitizenshipStatus { get; set; }

        public CitizenProfile(string name, string id, string citizenship)
        {
            FullName = name;
            IDNumber = id;
            CitizenshipStatus = citizenship;
        }

        private int CalculateAge()
        {
            try
            {
                string yymmdd = IDNumber.Substring(0, 6);

                int year = int.Parse(yymmdd.Substring(0, 2));
                int month = int.Parse(yymmdd.Substring(2, 2));
                int day = int.Parse(yymmdd.Substring(4, 2));

                int currentYear = DateTime.Now.Year % 100;
                int century = (year <= currentYear) ? 2000 : 1900;

                DateTime birthDate = new DateTime(century + year, month, day);

                int age = DateTime.Now.Year - birthDate.Year;
                if (DateTime.Now < birthDate.AddYears(age))
                    age--;

                return age;
            }
            catch
            {
                return -1; // invalid date
            }
        }

        public string ValidateID()
        {
            if (string.IsNullOrWhiteSpace(IDNumber))
                return "Invalid ID: Cannot be empty.";

            if (IDNumber.Length != 13)
                return "Invalid ID: Must be exactly 13 digits.";

            if (!long.TryParse(IDNumber, out _))
                return "Invalid ID: Must contain only numbers.";

            // SAFE to calculate age now
            Age = CalculateAge();

            if (Age < 0 || Age > 120)
                return "Invalid ID: Age is not realistic.";

            return $"Valid ID. Citizen is {Age} years old.";
        }

        public string GenerateSummary(string validationMessage)
        {
            return
                "======== DIGITAL CITIZEN SUMMARY ========\r\n\r\n" +
                $"Name:           {FullName}\r\n" +
                $"ID Number:      {IDNumber}\r\n" +
                $"Age:            {Age}\r\n" +
                $"Citizenship:    {CitizenshipStatus}\r\n" +
                $"Validation:     {validationMessage}\r\n\r\n" +
                $"Processed at:   Home Affairs Digital Desk\r\n" +
                $"Timestamp:      {DateTime.Now:yyyy/MM/dd HH:mm:ss}";
        }
    }
}


using System;

class Question5
{
    public static void Solve() 
    {
        while (true)
        {
            try
            {
                Console.Write("Please enter your date of birth (yyyy-MM-dd): ");
                string? input = Console.ReadLine();

                DateTime dob = DateTime.ParseExact(input, "yyyy-MM-dd", null);

                DateTime today = DateTime.Today;
                
                int ageYears = today.Year - dob.Year;
                int ageMonths = today.Month - dob.Month;
                int ageDays = today.Day - dob.Day;

                if (ageDays < 0)
                {
                    ageMonths--;
                    ageDays += DateTime.DaysInMonth(today.Year, today.Month);
                }

                if (ageMonths < 0)
                {
                    ageYears--;
                    ageMonths += 12;
                }

                Console.WriteLine($"You are {ageYears} years, {ageMonths} months, and {ageDays} days old.");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please use the format yyyy-MM-dd and try again.");
            }
        }
    }
}

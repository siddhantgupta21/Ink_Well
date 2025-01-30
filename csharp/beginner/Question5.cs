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

                if (string.IsNullOrEmpty(input))
                {
                    throw new ArgumentException("Input cannot be empty.");
                }

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
                Console.WriteLine("Error: The date format you entered is invalid. Please use the format yyyy-MM-dd.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message} Please enter a valid date in the format yyyy-MM-dd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}. Please try again.");
            }
        }
    }
}

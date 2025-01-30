using System;
using System.Collections.Generic;

class Question3
{
    public static void Solve()
    {
        while (true)
        {
            Console.WriteLine("Enter a list of comma-separated numbers (e.g., 5, 1, 9, 2, 10):");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid List. Please try again.");
                continue;
            }

            string[] numberStrings = input.Split(',');

            if (numberStrings.Length < 5)
            {
                Console.WriteLine("Invalid List. The list must include at least 5 numbers. Please try again.");
                continue;
            }

            List<int> numbers = new List<int>();
            bool isValid = true;

            for (int i = 0; i < numberStrings.Length; i++)
            {
                if (!int.TryParse(numberStrings[i].Trim(), out int number))
                {
                    Console.WriteLine($"Invalid entry '{numberStrings[i]}'. Please enter only valid numbers.");
                    isValid = false;
                    break;
                }
                numbers.Add(number);
            }

            if (!isValid)
            {
                continue;
            }
            List<int> smallestNumbers = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                int min = int.MaxValue;
                foreach (int num in numbers)
                {
                    if (!smallestNumbers.Contains(num) && num < min)
                    {
                        min = num;
                    }
                }

                smallestNumbers.Add(min);
            }

            Console.WriteLine($"The 3 smallest numbers are: {smallestNumbers[0]}, {smallestNumbers[1]}, {smallestNumbers[2]}");
            break; 
        }
    }
}


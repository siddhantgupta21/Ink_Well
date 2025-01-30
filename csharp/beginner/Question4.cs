using System;
using System.Collections.Generic;

class Question4
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

            numbers.Sort();
            numbers.Reverse();

            Console.WriteLine("Numbers in descending order:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            break; 
        }
    }
}

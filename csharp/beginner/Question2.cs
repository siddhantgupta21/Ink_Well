using System;
using System.Collections.Generic;

class Question2
{
    public static void Solve()
    {
        Console.WriteLine("Enter a series of numbers separated by commas (e.g., 5,3,8,1,4):");

        string? input = Console.ReadLine(); 
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cannot be empty.");
            return;
        }

        try
        {
            string[] parts = input.Split(',');
            List<int> numbers = new List<int>();

            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"Invalid number: '{part.Trim()}'. Skipping.");
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("No valid numbers entered.");
                return;
            }

            int max = numbers[0];
            foreach (var number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The maximum number is: {max}");
        }
        catch (Exception)
        {
            Console.WriteLine("An unexpected error occurred.");
        }
    }
}

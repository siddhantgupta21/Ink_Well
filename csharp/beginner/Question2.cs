using System;

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
            int[] numbers = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                numbers[i] = int.Parse(parts[i].Trim());
            }
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            Console.WriteLine($"The maximum number is: {max}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter numbers separated by commas.");
        }
    }
}

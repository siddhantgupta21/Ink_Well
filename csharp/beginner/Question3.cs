using System;

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

            int[] numbers = new int[numberStrings.Length];
            bool isValid = true;

            for (int i = 0; i < numberStrings.Length; i++)
            {
                if (!int.TryParse(numberStrings[i].Trim(), out numbers[i]))
                {
                    Console.WriteLine($"Invalid entry '{numberStrings[i]}'. Please enter only valid numbers.");
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                continue;
            }

           
            Array.Sort(numbers);
            Console.WriteLine($"The 3 smallest numbers are: {numbers[0]}, {numbers[1]}, {numbers[2]}");
            break; 
        }
    }
}

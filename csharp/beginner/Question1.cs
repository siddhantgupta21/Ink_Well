using System;

class Question1
{
    public static void Solve()
    {
        int sum = 0; 

        while (true)
        {
            Console.Write("Enter a number or type 'ok' to exit: ");
            string? input = Console.ReadLine(); 

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
                continue; 
            }

            if (input.ToLower() == "ok") 
            {
                break;
            }

            if (int.TryParse(input, out int number)) 
            {
                sum += number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'ok' to exit.");
            }
        }

        Console.WriteLine($"The sum of all entered numbers is: {sum}"); 
    }
}

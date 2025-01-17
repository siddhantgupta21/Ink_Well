using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose a question to run (1-6): ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Question1.Solve();
                break;
            case "2":
                Question2.Solve();
                break;
            case "3":
                Question3.Solve();
                break;
            case "4":
                Question4.Solve();
                break;
            case "5":
                Question5.Solve();
                break;
            case "6":
                Question6.Solve();
                break;
            default:
                Console.WriteLine("Invalid input. Please choose between 1 and 5.");
                break;
        }
    }
}

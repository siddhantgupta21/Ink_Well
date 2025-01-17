using System;
using System.IO;

class Question6
{
    public static void Solve() 
    {
        string filePath = "FavoriteMovies.txt";
        Console.WriteLine("Enter your favorite movies (one per line). Type 'done' when you are finished:");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            while (true)
            {
                string? movie = Console.ReadLine();

                if (string.IsNullOrEmpty(movie) || movie.ToLower() == "done")
                {
                    break; 
                }

                writer.WriteLine(movie); 
            }
        }

        Console.WriteLine("\nYour favorite movies in uppercase:");

        if (File.Exists(filePath))
        {
            string[] movies = File.ReadAllLines(filePath);

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.ToUpper());
            }
        }
        else
        {
            Console.WriteLine("The file does not exist.");
        }
    }
}

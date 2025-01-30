using System;
using System.Collections.Generic;
using System.IO;

class Question6
{
    public static void Solve() 
    {
        string filePath = "FavoriteMovies.txt";
        List<string> movies = new List<string>();

        Console.WriteLine("Enter your favorite movies (one per line). Type 'done' when you are finished:");

        while (true)
        {
            string? movie = Console.ReadLine();

            if (movie.ToLower() == "done")
            {
                break; 
            }

            movies.Add(movie); 
        }

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var movie in movies)
            {
                writer.WriteLine(movie); 
            }
        }

        Console.WriteLine("\nYour favorite movies in uppercase:");

        if (File.Exists(filePath))
        {
            string[] moviesFromFile = File.ReadAllLines(filePath);

            foreach (var movie in moviesFromFile)
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

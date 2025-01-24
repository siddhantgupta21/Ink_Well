using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDBApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IMovieService movieService = new MovieService();

            // while (true)
            // {
            //     // Show options to the user
            //     Console.WriteLine("\n--- IMDB Application ---");
            //     Console.WriteLine("1. List Movies");
            //     Console.WriteLine("2. Add Movie");
            //     Console.WriteLine("3. Exit");
            //     Console.Write("Choose an option: ");
            //     string input = Console.ReadLine();

            //     switch (input)
            //     {
            //         case "1":
            //             // List all movies
            //             var movies = movieService.GetMovies();
            //             if (movies.Count == 0)
            //             {
            //                 Console.WriteLine("\nNo movies available.");
            //             }
            //             else
            //             {
            //                 Console.WriteLine("\n--- List of Movies ---");
            //                 foreach (var movie in movies)
            //                 {
            //                     Console.WriteLine($"Movie: {movie.Name}, Year: {movie.YearOfRelease}");
            //                     Console.WriteLine($"Plot: {movie.Plot}");
            //                     Console.WriteLine("Actors: " + string.Join(", ", movie.Actors.ConvertAll(a => a.Name)));
            //                     Console.WriteLine($"Producer: {movie.Producer.Name}");
            //                     Console.WriteLine();
            //                 }
            //             }
            //             break;

            //         case "2":
            //             // Add a movie
            //             try
            //             {
            //                 movieService.AddMovie();
            //             }
            //             catch (ArgumentException ex)
            //             {
            //                 Console.WriteLine($"Error: {ex.Message}");
            //             }
            //             break;

            //         case "3":
            //             // Exit the application
            //             Console.WriteLine("Exiting the application...");
            //             return;

            //         default:
            //             Console.WriteLine("Invalid option. Please choose again.");
            //             break;
            //     }
            // }

            var movies = movieService.GetMovies();
                            // if (movies.Count == 0)
                            // {
                            //     Console.WriteLine("\nNo movies available.");
                            // }
                            // else
                            // {
                            //     Console.WriteLine("\n--- List of Movies ---");
                            //     foreach (var movie in movies)
                            //     {
                            //         Console.WriteLine($"Movie: {movie.Name}, Year: {movie.YearOfRelease}");
                            //         Console.WriteLine($"Plot: {movie.Plot}");
                            //         Console.WriteLine("Actors: " + string.Join(", ", movie.Actors.ConvertAll(a => a.Name)));
                            //         Console.WriteLine($"Producer: {movie.Producer.Name}");
                            //         Console.WriteLine();
                            //     }
                            // }

            var moviesAfter2010 = movies.Where(movie => movie.YearOfRelease > 2010);

            var moviesByJamesCameron = movies
                .Where(movie => movie.Producer?.Name == "James Cameron") // Safe access of Producer
                .Select(movie => movie.Name);

            var movieNamesAndYears = movies
                .Select(movie => new { movie.Name, movie.YearOfRelease });

            var avatarMovie = movies
                .FirstOrDefault(movie => movie.Name.Contains("Avatar", StringComparison.OrdinalIgnoreCase));

            var moviesWithWillSmith = movies
                .Where(movie => movie.Actors?.Any(actor => actor.Name.Equals("Will Smith", StringComparison.OrdinalIgnoreCase)) == true); 
            


            foreach (var movie in moviesAfter2010)
            {
                Console.WriteLine($"Movie: {movie.Name}, Year: {movie.YearOfRelease}");
            }
        }

    }
}

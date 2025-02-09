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
            Query query = new Query(movieService);

            while (true)
            {
                Console.WriteLine("\n--- IMDB Application ---");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var movies = movieService.GetMovies();
                        if (movies.Count == 0)
                        {
                            Console.WriteLine("\nNo movies available.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- List of Movies ---");
                            foreach (var movie in movies)
                            {
                                Console.WriteLine($"Movie: {movie.Name}, Year: {movie.YearOfRelease}");
                                Console.WriteLine($"Plot: {movie.Plot}");
                                Console.WriteLine("Actors: " + string.Join(", ", movie.Actors.ConvertAll(a => a.Name)));
                                Console.WriteLine($"Producer: {movie.Producer.Name}\n");
                            }
                        }
                        break;

                    case "2":
                        Console.Write("Enter the movie name: ");
                        string movieName = Console.ReadLine();

                        Console.Write("Enter the year of release: ");
                        int.TryParse(Console.ReadLine(), out int yearOfRelease);

                        Console.Write("Enter the plot of the movie: ");
                        string plot = Console.ReadLine();

                        Console.WriteLine("\nSelect actors (enter comma-separated indices of actors):");
                        var availableActors = movieService.GetAvailableActors();
                        for (int i = 0; i < availableActors.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {availableActors[i].Name}");
                        }

                        string actorSelection = Console.ReadLine();

                        Console.WriteLine("\nSelect a producer:");
                        var availableProducers = movieService.GetAvailableProducers();
                        for (int i = 0; i < availableProducers.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {availableProducers[i].Name}");
                        }

                        int.TryParse(Console.ReadLine(), out int producerSelection);

                        
                        movieService.AddMovie(movieName, yearOfRelease, plot, actorSelection, producerSelection);
                        
                        break;

                    case "3":
                        Console.WriteLine("Exiting the application...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
            var query1 = query.GetMoviesAfter2010();
            var query2= query.GetMoviesByProducer("Steven Spielberg");
            var query3 = query.GetAllMovies();
            var query4 = query.GetMovieByName("Avatar");
            var query5 = query.GetMoviesWithActor("Kate Winslet");

            foreach(var q in query2){
                Console.WriteLine($"{q}");
            }

            
            foreach(var i in query3){
                var a = (dynamic)i;
                Console.WriteLine($"{a.Name},{a.YearOfRelease}");
            }
            Console.WriteLine($"{query4.Name},{query4.YearOfRelease}");
        }
    }
}

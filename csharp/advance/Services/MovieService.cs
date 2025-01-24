using System;
using System.Collections.Generic;

namespace IMDBApplication
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService()
        {
            _movieRepository = new MovieRepository();
            InitializeMovies();
        }

   public void AddMovie(){
    Console.WriteLine("Enter the movie name:");
    string movieName = Console.ReadLine();
    while (string.IsNullOrEmpty(movieName))
    {
        Console.WriteLine("Movie name cannot be empty. Please enter a valid movie name:");
        movieName = Console.ReadLine();
    }

    Console.WriteLine("Enter the year of release:");
    int yearOfRelease;
    while (!int.TryParse(Console.ReadLine(), out yearOfRelease) || yearOfRelease <= 0)
    {
        Console.WriteLine("Invalid year. Please enter a valid positive integer for the year of release:");
    }

    Console.WriteLine("Enter the plot of the movie:");
    string plot = Console.ReadLine();
    while (string.IsNullOrEmpty(plot))
    {
        Console.WriteLine("Plot cannot be empty. Please enter a valid plot:");
        plot = Console.ReadLine();
    }

    Console.WriteLine("\nSelect actors (enter comma-separated indices of actors):");
    List<Actor> availableActors = GetAvailableActors();
    for (int i = 0; i < availableActors.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availableActors[i].Name}");
    }

    string actorSelection = Console.ReadLine();
    List<Actor> selectedActors = new List<Actor>();

    foreach (string index in actorSelection.Split(','))
    {
        if (int.TryParse(index.Trim(), out int actorIndex) && actorIndex > 0 && actorIndex <= availableActors.Count)
        {
            selectedActors.Add(availableActors[actorIndex - 1]);
        }
        else
        {
            Console.WriteLine("Invalid selection for actors. Please provide valid indices.");
        }
    }

    if (selectedActors.Count == 0)
    {
        Console.WriteLine("You must select at least one actor.");
        return;
    }

    Console.WriteLine("\nSelect a producer:");
    List<Producer> availableProducers = GetAvailableProducers();
    for (int i = 0; i < availableProducers.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availableProducers[i].Name}");
    }

    int producerSelection;
    while (!int.TryParse(Console.ReadLine(), out producerSelection) || producerSelection <= 0 || producerSelection > availableProducers.Count)
    {
        Console.WriteLine("Invalid selection. Please select a valid producer number.");
    }

    Producer selectedProducer = availableProducers[producerSelection - 1];
    if (selectedProducer == null)
    {
        Console.WriteLine("Producer cannot be null.");
        return;
    }

    // Ensure all information is valid before adding the movie
    if (string.IsNullOrEmpty(movieName) || yearOfRelease <= 0 || string.IsNullOrEmpty(plot) || selectedActors.Count == 0 || selectedProducer == null)
    {
        Console.WriteLine("Invalid movie data. Please ensure all fields are filled in correctly.");
        return;
    }

    // Create and add the new movie to the repository
    var movie = new Movie()
    {
        Name = movieName,
        Plot = plot,
        YearOfRelease = yearOfRelease,
        Actors = selectedActors,
        Producer = selectedProducer,
    };

    _movieRepository.Add(movie);
    Console.WriteLine("Movie added successfully!");
}


        private List<Actor> GetAvailableActors()
        {
            return new List<Actor>
            {
                new Actor("Leonardo DiCaprio"),
                new Actor("Matt Damon"),
                new Actor("Robert Downey Jr."),
                new Actor("Scarlett Johansson"),
                new Actor("Kate Winslet"),
                new Actor("Will Smith")  // Optional: Example for adding 'Will Smith' if required
            };
        }

        private List<Producer> GetAvailableProducers()
        {
            return new List<Producer>
            {
                new Producer("Steven Spielberg"),
                new Producer("Christopher Nolan"),
                new Producer("George Lucas"),
                new Producer("J.J. Abrams")
            };
        }

        private void InitializeMovies()
        {
            List<Actor> availableActors = GetAvailableActors();
            List<Producer> availableProducers = GetAvailableProducers();

            List<Movie> prepopulatedMovies = new List<Movie>
            {
                new Movie(
                    "Titanic",
                    "A tragic love story on a doomed ship.",
                    1997,
                    new List<Actor> { availableActors[0], availableActors[3] },
                    availableProducers[0]
                ),
                new Movie(
                    "Inception",
                    "A mind-bending thriller about dreams.",
                    2010,
                    new List<Actor> { availableActors[0], availableActors[1] },
                    availableProducers[1]
                ),
                new Movie(
                    "The Martian",
                    "A stranded astronaut's struggle to survive on Mars.",
                    2015,
                    new List<Actor> { availableActors[1] },
                    availableProducers[0]
                ),
                new Movie(
                    "Jurassic Park",
                    "Scientists bring dinosaurs back to life, but it goes terribly wrong.",
                    1993,
                    new List<Actor> { availableActors[1], availableActors[4] },
                    availableProducers[0]
                ),
                new Movie(
                    "The Dark Knight",
                    "A gritty and realistic portrayal of the Batman story.",
                    2008,
                    new List<Actor> { availableActors[2] },
                    availableProducers[1]
                ),
                new Movie(
                    "Avatar",
                    "A paraplegic marine on an alien planet becomes part of a new world.",
                    2009,
                    new List<Actor> { availableActors[0], availableActors[3] },
                    availableProducers[3]
                ),
            };

            foreach (var movie in prepopulatedMovies)
            {
                 _movieRepository.Add(movie);
            }
        }

        public List<Movie> GetMovies()
        {
            return _movieRepository.GetAll();
        }
    }
}

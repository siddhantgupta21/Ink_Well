using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddMovie(string movieName, int yearOfRelease, string plot, string actorSelection, int producerSelection)
        {
            try
            {
                if (string.IsNullOrEmpty(movieName))
                    throw new CustomException("Movie Name is Empty");

                if (yearOfRelease <= 0 || yearOfRelease > DateTime.Now.Year)
                    throw new CustomException("Invalid year of release.");

                List<Actor> availableActors = GetAvailableActors();
                List<Actor> selectedActors = new List<Actor>();

                foreach (string index in actorSelection.Split(','))
                {
                    if (int.TryParse(index.Trim(), out int actorIndex) && actorIndex > 0 && actorIndex <= availableActors.Count)
                    {
                        selectedActors.Add(availableActors[actorIndex - 1]);
                    }
                }

                if (selectedActors.Count == 0)
                    throw new CustomException("You must select at least one actor.");

                List<Producer> availableProducers = GetAvailableProducers();
                if (producerSelection <= 0 || producerSelection > availableProducers.Count)
                    throw new CustomException("Invalid producer selection.");

                Producer selectedProducer = availableProducers[producerSelection - 1];

                var movie = new Movie()
                {
                    Name = movieName,
                    Plot = plot,
                    YearOfRelease = yearOfRelease,
                    Actors = selectedActors,
                    Producer = selectedProducer,
                };

                _movieRepository.Add(movie);
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
        }


        public List<Movie> GetMovies()
        {
            return _movieRepository.GetAll();
        }

        public List<Actor> GetAvailableActors()
        {
            return new List<Actor>
            {
                new Actor("Leonardo DiCaprio"),
                new Actor("Matt Damon"),
                new Actor("Robert Downey Jr."),
                new Actor("Scarlett Johansson"),
                new Actor("Kate Winslet"),
                new Actor("Will Smith")
            };
        }

        public List<Producer> GetAvailableProducers()
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
                new Movie { Name = "Titanic", Plot = "A tragic love story on a doomed ship.", YearOfRelease = 1997, Actors = new List<Actor> { availableActors[0], availableActors[3] }, Producer = availableProducers[0] },
                new Movie { Name = "Inception", Plot = "A mind-bending thriller about dreams.", YearOfRelease = 2010, Actors = new List<Actor> { availableActors[0], availableActors[1] }, Producer = availableProducers[1] },
                new Movie { Name = "The Martian", Plot = "A stranded astronaut's struggle to survive on Mars.", YearOfRelease = 2015, Actors = new List<Actor> { availableActors[1] }, Producer = availableProducers[0] },
                new Movie { Name = "Jurassic Park", Plot = "Scientists bring dinosaurs back to life, but it goes terribly wrong.", YearOfRelease = 1993, Actors = new List<Actor> { availableActors[1], availableActors[4] }, Producer = availableProducers[0] },
                new Movie { Name = "The Dark Knight", Plot = "A gritty and realistic portrayal of the Batman story.", YearOfRelease = 2008, Actors = new List<Actor> { availableActors[2] }, Producer = availableProducers[1] },
                new Movie { Name = "Avatar", Plot = "A paraplegic marine on an alien planet becomes part of a new world.", YearOfRelease = 2009, Actors = new List<Actor> { availableActors[0], availableActors[3] }, Producer = availableProducers[3] }
            };

            foreach (var movie in prepopulatedMovies)
            {
                _movieRepository.Add(movie);
            }
        }

         public List<Movie> GetMoviesAfter2010()
        {
            return _movieRepository.GetAll().Where(movie=> movie.YearOfRelease>=2010).ToList();
        }

        public List<string> GetMoviesByProducer(string producerName)
        {
            return _movieRepository.GetAll().Where(movie=> movie.Producer.Name==producerName).Select(movie=>movie.Name).ToList();
        }

        public List<object> GetAllMovies()
        {
            return _movieRepository.GetAll().Select(movie => new {movie.Name,movie.YearOfRelease}).Cast<object>().ToList();
        }

        public Movie GetMovieByName(string movieName)
        {
            return _movieRepository.GetAll().FirstOrDefault(movie=>movie.Name=="Avatar");
        }

        public List<Movie> GetMoviesWithActor(string actorName)
        {
            return _movieRepository.GetAll().Where(movies=>movies.Actors.Any(actor=>actor.Name==actorName)).ToList();
        }

        public void ValidateYearOfRelease(int yearOfRelease)
        {
            if (yearOfRelease < 1888 || yearOfRelease > DateTime.Now.Year)
            {
                throw new CustomException("Invalid release year. Enter a valid year.");
            }
        }

        public void ValidateActorsSelection(string actorSelection)
        {
            var availableActors = GetAvailableActors();
            var selectedActorIds = actorSelection.Split(',')
                                                .Select(s => int.TryParse(s.Trim(), out int id) ? id : -1)
                                                .ToList();

            if (selectedActorIds.Any(id => id < 1 || id > availableActors.Count))
            {
                throw new CustomException("Invalid actor selection.");
            }
        }

        public void ValidateProducerSelection(int producerSelection)
        {
            var availableProducers = GetAvailableProducers();
            if (producerSelection < 1 || producerSelection > availableProducers.Count)
            {
                throw new CustomException("Invalid producer selection.");
            }
        }

        
    }
}


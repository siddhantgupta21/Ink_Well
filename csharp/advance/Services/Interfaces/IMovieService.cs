

namespace IMDBApplication
{
    using System.Collections.Generic;
    public interface IMovieService
    {
        void AddMovie(string movieName, int yearOfRelease, string plot, string actorSelection, int producerSelection);
        List<Movie> GetMovies();
        List<Actor> GetAvailableActors();
        List<Producer> GetAvailableProducers();

        List<Movie> GetMoviesAfter2010();
        List<string> GetMoviesByProducer(string producerName);

        List<object> GetAllMovies();
        Movie GetMovieByName(string movieName);

        List<Movie> GetMoviesWithActor(string actorName);

        void ValidateYearOfRelease(int yearOfRelease);
        void ValidateActorsSelection(string actorSelection);
        void ValidateProducerSelection(int producerSelection);
    }
}

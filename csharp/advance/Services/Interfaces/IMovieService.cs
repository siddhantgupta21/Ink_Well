using System.Collections.Generic;

namespace IMDBApplication
{
    public interface IMovieService
    {
        void AddMovie(string movieName, int yearOfRelease, string plot, string actorSelection, int producerSelection);
        List<Movie> GetMovies();
        List<Actor> GetAvailableActors();
        List<Producer> GetAvailableProducers();
    }
}

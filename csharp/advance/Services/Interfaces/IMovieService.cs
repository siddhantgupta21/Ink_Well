

namespace IMDBApplication
{
    using System.Collections.Generic;
    public interface IMovieService
    {
        void AddMovie(string movieName, int yearOfRelease, string plot, string actorSelection, int producerSelection);
        List<Movie> GetMovies();
        List<Actor> GetAvailableActors();
        List<Producer> GetAvailableProducers();
    }
}

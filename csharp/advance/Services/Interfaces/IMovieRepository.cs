using System.Collections.Generic;

namespace IMDBApplication
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        List<Movie> GetAll();
    }
}

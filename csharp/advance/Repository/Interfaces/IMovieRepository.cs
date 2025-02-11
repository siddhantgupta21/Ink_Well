
namespace IMDBApplication
{
    using System.Collections.Generic;

    public interface IMovieRepository
    {
        void Add(Movie movie);
        List<Movie> GetAll();
    }
}

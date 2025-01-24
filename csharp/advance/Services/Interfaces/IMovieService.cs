using System;
using System.Collections.Generic;

namespace IMDBApplication
{
    public interface IMovieService
    {
        void AddMovie();

        List<Movie> GetMovies();
    }
}

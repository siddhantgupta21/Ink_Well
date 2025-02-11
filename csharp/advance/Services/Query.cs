using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDBApplication
{
    public class Query
    {
        private readonly IMovieService _movieservice;
        private readonly List<Movie> AllMovies;

        public Query(IMovieService movieService){
            _movieservice = movieService;
            AllMovies = movieService.GetMovies();
        }

       

    }
}




namespace IMDBApplication{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public List<Movie> GetAll()
        {
            return _movies.ToList();
        }
    }
}

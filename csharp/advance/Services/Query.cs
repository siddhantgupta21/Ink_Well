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

        public List<Movie> GetMoviesAfter2010()
        {
            return AllMovies.Where(movie=> movie.YearOfRelease>=2010).ToList();
        }

        public List<string> GetMoviesByProducer(string producerName)
        {
            return AllMovies.Where(movie=> movie.Producer.Name==producerName).Select(movie=>movie.Name).ToList();
        }

        public List<object> GetAllMovies()
        {
            return AllMovies.Select(movie => new {movie.Name,movie.YearOfRelease}).Cast<object>().ToList();
        }

        public Movie GetMovieByName(string movieName)
        {
            return AllMovies.FirstOrDefault(movie=>movie.Name=="Avatar");
        }

        public List<Movie> GetMoviesWithActor(string actorName)
        {
            return AllMovies.Where(movies=>movies.Actors.Any(actor=>actor.Name==actorName)).ToList();
        }

    }
}


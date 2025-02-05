
namespace IMDBApplication
{

    using System;
    using System.Collections.Generic;

    public class Movie
    {
        public required string Name { get; set; } 
        public required int YearOfRelease { get; set; }
        public string? Plot { get; set; } 
        public required List<Actor> Actors { get; set; } 
        public required Producer Producer { get; set; } 

        public Movie(string name, string plot, int yearOfRelease, List<Actor> actors, Producer producer)
        {
            Name = name;
            Plot = plot;
            YearOfRelease = yearOfRelease;
            Actors = actors;
            Producer = producer;
        }

        public Movie(){}

  
        public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message) { }
        }
}
}
using System;
using System.Collections.Generic;

namespace IMDBApplication
{
    public class Movie
    {
        public string? Name { get; set; } 
        public int YearOfRelease { get; set; }
        public string? Plot { get; set; } 
        public List<Actor>? Actors { get; set; } 
        public Producer? Producer { get; set; } 

        public Movie(string name, string plot, int yearOfRelease, List<Actor> actors, Producer producer)
        {
            Name = name;
            Plot = plot;
            YearOfRelease = yearOfRelease;
            Actors = actors;
            Producer = producer;
        }

        public Movie(){}

        // public override string ToString()
        // {
        //     return $"Movie: {Name}, Year: {YearOfRelease}, Plot: {Plot}, Producer: {Producer.Name}, Actors: {string.Join(", ", Actors)}";
        // }
    }
   public class Actor
    {
        // Actor Name
        public string Name { get; set; }

        public Actor(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Producer
    {
        // Producer Name
        public string Name { get; set; }

        public Producer(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    // Custom Exception for Validation Errors
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using MOVIETICKETBOOKINGSYSTEM.Interfaces;

namespace MOVIETICKETBOOKINGSYSTEM.Services
{
    public class MovieService : IMovieService
    {
        private readonly List<string> _movies;

        public MovieService()
        {
            _movies = new List<string>
            {
                "Inception",
                "Interstellar",
                "The Dark Knight",
                "Avengers: Endgame",
                "Parasite"
            };
        }

        public List<string> GetAvailableMovies() => _movies;

        public string SelectMovie(int choice)
        {
            if (choice < 1 || choice > _movies.Count)
                throw new ArgumentException("Invalid movie selection.");
            
            return _movies[choice - 1];
        }
    }
}

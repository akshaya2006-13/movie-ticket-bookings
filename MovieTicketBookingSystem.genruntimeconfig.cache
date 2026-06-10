using System;
using System.Collections.Generic;

namespace BookMyShow.Showtimes
{
    public class ShowtimeService : IShowtimeService
    {
        private readonly Dictionary<string, List<string>> _showtimes =
            new Dictionary<string, List<string>>
            {
                { "Inception", new List<string> { "10:00 AM", "2:00 PM", "6:00 PM" } },
                { "Interstellar", new List<string> { "11:00 AM", "3:00 PM", "7:00 PM" } },
                { "The Dark Knight", new List<string> { "12:00 PM", "4:00 PM", "8:00 PM" } }
            };

        public List<string> GetShowtimes(string movie)
        {
            return _showtimes.ContainsKey(movie) ? _showtimes[movie] : new List<string>();
        }

        public string SelectShowtime(int choice, string movie)
        {
            var times = GetShowtimes(movie);
            if (choice < 1 || choice > times.Count)
                throw new ArgumentException("Invalid showtime selection.");
            return times[choice - 1];
        }
    }
}

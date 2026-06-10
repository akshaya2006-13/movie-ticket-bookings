using System.Collections.Generic;

namespace BookMyShow
{

    public interface IShowtimeService
    {
        List<string> GetShowtimes(string movie);
        string SelectShowtime(int choice, string movie);
    }
}

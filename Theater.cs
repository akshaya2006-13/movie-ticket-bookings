using System.Collections.Generic;

namespace MOVIETICKETBOOKINGSYSTEM.Interfaces
{
    public interface IMovieService
    {
        List<string> GetAvailableMovies();
        string SelectMovie(int choice);
    }
}

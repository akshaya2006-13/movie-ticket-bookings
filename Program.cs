public interface ISeatService
{
    void DisplaySeats(string showtime, List<(int Row, int Col)> reservedSeats);
    bool BookSeat(int row, int col, string showtime);
    List<(int Row, int Col)> BookSelectedSeats(List<(int Row, int Col)> seats, string showtime);
}

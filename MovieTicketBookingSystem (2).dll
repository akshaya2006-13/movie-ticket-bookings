using System;
using System.Collections.Generic;
using System.Linq; // Needed for Any()
using MOVIETICKETBOOKINGSYSTEM.Interfaces;

namespace MOVIETICKETBOOKINGSYSTEM.Services
{
    public class SeatService : ISeatService
    {
        private readonly Dictionary<string, bool[,]> _seatMaps =
            new Dictionary<string, bool[,]>();

        private void EnsureShowtimeExists(string showtime)
        {
            if (!_seatMaps.ContainsKey(showtime))
            {
                _seatMaps[showtime] = new bool[5, 5]; // 5x5 grid
            }
        }

        public void DisplaySeats(string showtime, List<(int Row, int Col)> reservedSeats)
        {
            EnsureShowtimeExists(showtime);
            var seats = _seatMaps[showtime];

            Console.WriteLine("\nSeat Layout (G = available, R = booked):");
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    bool isReserved = reservedSeats.Any(s => s.Row == i && s.Col == j);
                    Console.Write(isReserved || seats[i, j] ? "R " : "G ");
                }
                Console.WriteLine();
            }
        }

        public bool BookSeat(int row, int col, string showtime)
        {
            EnsureShowtimeExists(showtime);
            var seats = _seatMaps[showtime];

            if (seats[row, col])
                throw new InvalidOperationException($"Seat at Row {row}, Col {col} is already booked.");

            seats[row, col] = true;
            return true;
        }

        public List<(int Row, int Col)> BookSelectedSeats(List<(int Row, int Col)> seatsToBook, string showtime)
        {
            EnsureShowtimeExists(showtime);
            var seats = _seatMaps[showtime];
            var bookedSeats = new List<(int, int)>();

            foreach (var seat in seatsToBook)
            {
                if (seats[seat.Row, seat.Col])
                    throw new InvalidOperationException($"Seat at Row {seat.Row}, Col {seat.Col} is already booked.");

                seats[seat.Row, seat.Col] = true;
                bookedSeats.Add(seat);
            }

            return bookedSeats;
        }
    }
}

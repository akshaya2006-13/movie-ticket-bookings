using System;
using System.IO;
using System.Collections.Generic;

namespace MOVIETICKETBOOKINGSYSTEM.Services
{
    public class FileService
    {
        private readonly string _bookingFilePath;
        private readonly string _reservedSeatsFilePath;

        public FileService()
        {
            Directory.CreateDirectory("Bookings");

            _bookingFilePath = Path.Combine("Bookings", "booking.txt");
            _reservedSeatsFilePath = Path.Combine("Bookings", "reservedseats.txt");
        }

        // Save booking record
        public void SaveBooking(string bookingRecord)
        {
            File.AppendAllText(_bookingFilePath, bookingRecord + Environment.NewLine);
        }

        // Display booking history
        public void DisplayBookingHistory()
        {
            if (File.Exists(_bookingFilePath))
            {
                Console.WriteLine("\nBooking History");
                string content = File.ReadAllText(_bookingFilePath);
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("No Booking History Found");
            }
        }

        // ✅ Save reserved seats for a movie, theater, and show
        public void SaveReservedSeats(int movieId, int theaterId, int showId, List<(int Row, int Col)> seats)
        {
            using (StreamWriter sw = new StreamWriter(_reservedSeatsFilePath, true))
            {
                foreach (var seat in seats)
                {
                    sw.WriteLine($"{movieId},{theaterId},{showId},{seat.Row},{seat.Col}");
                }
            }
        }

        // ✅ Load reserved seats for a specific movie, theater, and show
        public List<(int Row, int Col)> LoadReservedSeats(int movieId, int theaterId, int showId)
        {
            var reservedSeats = new List<(int, int)>();

            if (File.Exists(_reservedSeatsFilePath))
            {
                var lines = File.ReadAllLines(_reservedSeatsFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 5 &&
                        int.Parse(parts[0]) == movieId &&
                        int.Parse(parts[1]) == theaterId &&
                        int.Parse(parts[2]) == showId)
                    {
                        reservedSeats.Add((int.Parse(parts[3]), int.Parse(parts[4])));
                    }
                }
            }

            return reservedSeats;
        }

        // ✅ Clear reserved seats (optional utility)
        public void ClearReservedSeats()
        {
            if (File.Exists(_reservedSeatsFilePath))
            {
                File.WriteAllText(_reservedSeatsFilePath, string.Empty);
                Console.WriteLine("Reserved seats cleared successfully.");
            }
            else
            {
                Console.WriteLine("No reserved seats found to clear.");
            }
        }
    }
}

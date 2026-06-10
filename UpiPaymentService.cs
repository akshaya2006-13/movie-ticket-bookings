using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using MOVIETICKETBOOKINGSYSTEM.Exceptions;
using MOVIETICKETBOOKINGSYSTEM.Interfaces;
using MOVIETICKETBOOKINGSYSTEM.Models;
using MOVIETICKETBOOKINGSYSTEM.Services;

namespace MOVIETICKETBOOKINGSYSTEM
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Program Started");
            try
            {
                // Step 1: Load Movies
                Console.WriteLine("\n--- Available Movies ---");
                var movieLines = File.ReadAllLines("Data/movies.txt");
                foreach (var line in movieLines)
                {
                    var parts = line.Split(',');
                    Console.WriteLine($"ID: {parts[0]}, Title: {parts[1]}, Language: {parts[2]}, Duration: {parts[3]} mins");
                }

                Console.Write("\nEnter Movie ID: ");
                int movieId = int.Parse(Console.ReadLine() ?? "0");
                var movieParts = movieLines.FirstOrDefault(l => l.StartsWith(movieId + ","))?.Split(',');
                if (movieParts == null) throw new BookingException("Invalid Movie ID selected.");
                Movie movie = new Movie(int.Parse(movieParts[0]), movieParts[1], movieParts[2], int.Parse(movieParts[3]));

                // Step 2: Theater
                Console.WriteLine("\n--- Available Theaters ---");
                var theaterLines = File.ReadAllLines("Data/theaters.txt");
                foreach (var line in theaterLines)
                {
                    var parts = line.Split(',');
                    Console.WriteLine($"ID: {parts[0]}, Name: {parts[1]}, Location: {parts[2]}");
                }

                Console.Write("\nEnter Theater ID: ");
                int theaterId = int.Parse(Console.ReadLine() ?? "0");
                var theaterParts = theaterLines.FirstOrDefault(l => l.StartsWith(theaterId + ","))?.Split(',');
                if (theaterParts == null) throw new BookingException("Invalid Theater ID selected.");
                Theater theater = new Theater(int.Parse(theaterParts[0]), theaterParts[1], theaterParts[2]);

                // Step 3: Show
                Console.WriteLine("\n--- Available Shows ---");
                var showLines = File.ReadAllLines("Data/shows.txt");
                foreach (var line in showLines)
                {
                    var parts = line.Split(',');
                    Console.WriteLine($"Show ID: {parts[0]}, Movie ID: {parts[1]}, Theater ID: {parts[2]}, Time: {parts[3]}");
                }

                Console.Write("\nEnter Show ID: ");
                int showId = int.Parse(Console.ReadLine() ?? "0");
                var showParts = showLines.FirstOrDefault(l => l.StartsWith(showId + ","))?.Split(',');
                if (showParts == null) throw new BookingException("Invalid Show ID selected.");
                Show show = new Show(int.Parse(showParts[0]), movie, theater, DateTime.Parse(showParts[3]));

                // Step 4: Customer Registration
                Console.WriteLine("\n--- Customer Registration ---");
                ICustomerRegistrationService registrationService = new CustomerRegistrationService();
                string name, email, phone;
                while (true)
                {
                    try
                    {
                        Console.Write("Enter your name: ");
                        name = Console.ReadLine() ?? string.Empty;

                        Console.Write("Enter your email: ");
                        email = Console.ReadLine() ?? string.Empty;

                        Console.Write("Enter your phone number: ");
                        phone = Console.ReadLine() ?? string.Empty;

                        string regResult = registrationService.RegisterCustomer(name, email, phone);
                        Console.WriteLine(regResult);
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Validation Error: {ex.Message}. Please try again.\n");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Registration Error: {ex.Message}. Please try again.\n");
                    }
                }

                // Step 5: Booking Details
                Console.WriteLine("\n--- Booking Details ---");
                Console.Write("Enter number of tickets: ");
                int ticketCount = int.Parse(Console.ReadLine() ?? "0");

                var priceLines = File.ReadAllLines("Data/ticketprices.txt");
                var priceEntry = priceLines.FirstOrDefault(l =>
                {
                    var parts = l.Split(',');
                    return parts[0] == movie.Id.ToString() && parts[1] == theater.Id.ToString();
                });
                if (priceEntry == null) throw new BookingException("Ticket price not found.");

                var priceParts = priceEntry.Split(',');
                decimal costPerTicket = decimal.Parse(priceParts[2]);
                decimal totalAmount = ticketCount * costPerTicket;

                Booking booking = new Booking(101, name, show, ticketCount, (int)totalAmount);
                Console.WriteLine($"Booking created for {ticketCount} tickets. Total: {totalAmount}");

                // Step 6: Seat Selection
                ISeatService seatService = new SeatService();
                FileService fileService = new FileService(); // ✅ declare once here

                var reservedSeats = fileService.LoadReservedSeats(movie.Id, theater.Id, show.Id);
                seatService.DisplaySeats(show.ShowTime.ToString(), reservedSeats);

                var seatsToBook = new List<(int, int)>();
                for (int i = 0; i < ticketCount; i++)
                {
                    Console.WriteLine($"\nSelect seat for ticket {i + 1}:");
                    Console.Write("Enter Row (0-4): ");
                    int row = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter Column (0-4): ");
                    int col = int.Parse(Console.ReadLine() ?? "0");

                    if (reservedSeats.Exists(s => s.Item1 == row && s.Item2 == col))
                    {
                        Console.WriteLine("Seat already reserved. Choose another.");
                        i--;
                        continue;
                    }
                    seatsToBook.Add((row, col));
                }

                fileService.SaveReservedSeats(movie.Id, theater.Id, show.Id, seatsToBook);

                Console.WriteLine("\nSeats booked successfully:");
                foreach (var seat in seatsToBook)
                    Console.WriteLine($"Row {seat.Item1}, Column {seat.Item2}");

                Console.WriteLine("\nUpdated Seat Layout:");
                var updatedReservedSeats = fileService.LoadReservedSeats(movie.Id, theater.Id, show.Id);
                seatService.DisplaySeats(show.ShowTime.ToString(), updatedReservedSeats);

                // Step 7: Payment
                Console.WriteLine("\n--- Payment Options ---");
                Console.WriteLine("1. UPI");
                Console.WriteLine("2. Card");
                Console.Write("Choose payment method (1 or 2): ");
                string paymentChoice = Console.ReadLine() ?? "1";
                IPaymentService paymentService;
                if (paymentChoice == "2")
                {
                    Console.WriteLine("\n--- Enter Card Details ---");
                    Console.Write("Card Number (16 digits): ");
                    string cardNumber = Console.ReadLine() ?? string.Empty;
                    Console.Write("Expiry Date (MM/YY): ");
                    string expiryDate = Console.ReadLine() ?? string.Empty;
                    Console.Write("CVV (3 digits): ");
                    string cvv = Console.ReadLine() ?? string.Empty;

                    paymentService 
                    = new CardPaymentService(cardNumber, expiryDate, cvv);
                }
                else
                {
                    Console.WriteLine("\n--- Enter UPI Details ---");
                    Console.Write("Enter UPI ID (e.g., name@bank): ");
                    string upiId = Console.ReadLine() ?? string.Empty;

                    paymentService = new UpiPaymentService(upiId);
                }


                // Step 8: Finalize Booking
                INotificationService notificationService = new EmailNotificationService();
                BookingService bookingService = new BookingService(paymentService, notificationService, fileService);
                bookingService.BookTicket(booking);

                // Step 9: Booking History
                fileService.DisplayBookingHistory();
            }
            catch (BookingException ex)
            {
                Console.WriteLine($"Booking Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"System Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nApplication Closed");
            }
        }
    }
}

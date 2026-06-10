using MOVIETICKETBOOKINGSYSTEM.Exceptions;
using MOVIETICKETBOOKINGSYSTEM.Interfaces;
using MOVIETICKETBOOKINGSYSTEM.Models;

namespace MOVIETICKETBOOKINGSYSTEM.Services;

public class BookingService
{
    private readonly IPaymentService _paymentService;
    private readonly INotificationService _notificationsService;

    private readonly FileService _fileService;

    public BookingService(IPaymentService paymentService, INotificationService notificationsService, FileService fileService)
    {
        _paymentService = paymentService;
        _notificationsService = notificationsService;
        _fileService = fileService;
    }

    public void BookTicket(Booking booking)
    {
        if (booking.TicketCount <= 0)
        {
            throw new BookingException("Ticket Must Be Greater Than Zero");
        }

        if (booking.Amount <= 0)
        {
            throw new BookingException("Amount Must Be Greater Than Zero");
        }

        _paymentService.ProcessPayment(booking.Amount);
        _notificationsService.SendNotification("Booking Successful");

        string bookingRecord =
        $"Customer : {booking.CustomerName} | " +
        $"Movie : {booking.Show.Movie.Title} | " +
        $"Theater : {booking.Show.Theater.Name} | " +
        $"Show Time : {booking.Show.ShowTime} | " +
        $"Tickets : {booking.TicketCount} | " +
        $"Amount : {booking.Amount}";


        _fileService.SaveBooking(bookingRecord);

        Console.WriteLine("\nBooking Completed Successfully");


    }


}
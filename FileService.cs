namespace MOVIETICKETBOOKINGSYSTEM.Models;

public class Booking: BaseEntity
{
    public string CustomerName{get; set;}="";
    public int TicketCount {get; set;}
    public decimal Amount{get; set;}=0.00m;

    public Show Show{get; set;}

    public Booking(int id, string customerName, Show show, int ticketCount, decimal amount)
    {
        Id = id;
        CustomerName = customerName;
        Show = show;
        TicketCount = ticketCount;
        Amount = amount;
    }
}
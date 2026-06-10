namespace MOVIETICKETBOOKINGSYSTEM.Models;

public class Show : BaseEntity
{
    public Movie Movie{get; set;}
    public Theater Theater{get; set;}

    public DateTime ShowTime {get; set;}

    public Show(int id, Movie movie, Theater theater, DateTime showTime)
    {
        Id = id;
        Movie = movie;
        Theater = theater;
        ShowTime = showTime;
    }



}
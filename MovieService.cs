namespace MOVIETICKETBOOKINGSYSTEM.Models;

public class Movie : BaseEntity
{
    public string Title {get; set;} = "";

    public string Language {get; set;}="";

    public int Duration {get; set;}=0;


    public Movie (
        int id,
        string title,
        string language,
        int duration)
    
    {
        Id = id;
        Title = title;
        Language = language;
        Duration = duration;
    }
}
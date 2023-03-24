namespace WebApi;

public class Assignment
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public int Grade {get;set;}
    public DateTime DueDate {get;set;}
}

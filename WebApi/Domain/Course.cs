namespace WebApi;

public class Course
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public List<Module> Modules {get;set;}
}

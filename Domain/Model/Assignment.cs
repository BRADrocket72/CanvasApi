
using System;

namespace Model;

public class Assignment
{
    public Guid Id { get; set; }

    public string Name { get; set; } = String.Empty;
    public int Grade { get; set; }
    public DateTime DueDate { get; set; }

}

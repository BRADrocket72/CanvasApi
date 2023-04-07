using System;
using System.Collections.Generic;

namespace Model;

public class Course
{
    public Guid Id { get; set; }

    public string Name { get; set; }= String.Empty;
    public List<Module> Modules {get;set;}
}

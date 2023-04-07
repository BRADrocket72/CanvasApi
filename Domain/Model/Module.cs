using System;
using System.Collections.Generic;

namespace Model;

public class Module
{
    public Guid Id { get; set; }

    public string Name { get; set; } = String.Empty;
    public List<Assignment> Assignments {get;set;}

}

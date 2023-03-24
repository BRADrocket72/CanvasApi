using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AssignmentController : ControllerBase
{

    public AssignmentController()
    {
    }
    private static Assignment assignment1 = new Assignment { Id = new Guid("7758e920-5e0f-4cf2-9b35-d76c1a1c3bbe"), Name = "homework", DueDate = DateTime.Now, Grade = 90 };
    private static Assignment assignment2 = new Assignment { Id = new Guid("1158e920-5e0f-4cf2-9b35-d76c1a1c3b33"), Name = "homework2", DueDate = DateTime.Now, Grade = 85 };
    private static List<Assignment> allAssignments = new List<Assignment> { assignment1, assignment2 };

    [HttpGet()]
    public IEnumerable<Assignment> GetAll()
    {
        return allAssignments;
    }

    [HttpGet("/{assignmentId}")]
    public Assignment GetAssignment(Guid assignmentId)
    {
        return allAssignments.Find(x => x.Id == assignmentId);
    }

    [HttpPost]
    public Assignment CreateAssignment([FromBody] Assignment assignment)
    {
        allAssignments.Add(assignment);
        return assignment;
    }

    [HttpPut]
    public Assignment UpdateAssignment([FromBody] Assignment assignment)
    {
        allAssignments.Remove(assignment);
        allAssignments.Add(assignment);
        return assignment;
    }

}

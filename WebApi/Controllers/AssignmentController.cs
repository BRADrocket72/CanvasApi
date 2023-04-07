using Microsoft.AspNetCore.Mvc;
using Model;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentRepository assignmentRepository;
    public AssignmentController(IAssignmentRepository assignmentRepository)
    {
        this.assignmentRepository = assignmentRepository;
    }


    [HttpGet()]
    public IEnumerable<Assignment> GetAll()
    {
        return assignmentRepository.GetAssignments();
    }

    [HttpGet("/{assignmentId}")]
    public Assignment GetAssignment(Guid assignmentId)
    {
        Assignment assignment = assignmentRepository.GetAssignment(assignmentId);
        return assignment;
    }

    [HttpPost]
    public Assignment CreateAssignment([FromBody] Assignment assignment)
    {
        return assignmentRepository.CreateAssignment(assignment);
    }

    [HttpPut]
    public Assignment UpdateAssignment([FromBody] Assignment assignment)
    {
        return assignmentRepository.UpdateAssignment(assignment);
    }

}

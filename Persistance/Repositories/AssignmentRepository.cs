

using Model;

public interface IAssignmentRepository
{
    IEnumerable<Assignment> GetAssignments();
    Assignment GetAssignment(Guid assignmentId);
    Assignment CreateAssignment(Assignment assignment);
    Assignment UpdateAssignment(Assignment assignment);
    Guid DeleteAssignment(Guid assignmentId);

}

public class AssignmentRepository : IAssignmentRepository
{
    private readonly CanvasContext canvasContext;
    public AssignmentRepository(CanvasContext canvasContext)
    {
        this.canvasContext = canvasContext;
    }

    public IEnumerable<Assignment> GetAssignments()
    {
        return canvasContext.Assignments.Select(x => new Assignment { Name = x.Name, Grade = x.Grade, Id = x.Id, DueDate = x.DueDate });
    }

    public Assignment GetAssignment(Guid assignmentId)
    {
        Assignment? assignment = canvasContext.Assignments.First(x => x.Id == assignmentId);
        return assignment;
    }

    public Assignment CreateAssignment(Assignment assignment)
    {
        canvasContext.Assignments.Add(assignment);
        canvasContext.SaveChanges();
        return assignment;
    }
    public Assignment UpdateAssignment(Assignment assignment)
    {
        Assignment updatedAssignment = canvasContext.Update(assignment).Entity;
        canvasContext.SaveChanges();
        return updatedAssignment;

    }

    public Guid DeleteAssignment(Guid assignmentId)
    {
        Assignment assignment = canvasContext.Assignments.First(x => x.Id == assignmentId);
        canvasContext.Assignments.Remove(assignment);
        canvasContext.SaveChanges();
        return assignmentId;
    }
}
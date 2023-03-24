using WebApi;
using WebApi.Controllers;

namespace WebApiTests;

public class AssignmentControllerTests
{
    AssignmentController controller = new AssignmentController();
    Guid assignment1Id = new Guid("7758e920-5e0f-4cf2-9b35-d76c1a1c3bbe");
    [Fact]
    public void ReturnsMany()
    {
        var result = controller.GetAll();
        Assert.Equal(result.Count(), 2);
    }

    [Fact]
    public void When_GetById_ReturnsObjWithId()
    {
        var result = controller.GetAssignment(assignment1Id);
        Assert.Equal(result.Id, assignment1Id);
    }

}
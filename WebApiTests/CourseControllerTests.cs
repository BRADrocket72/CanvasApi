using WebApi;
using WebApi.Controllers;

namespace WebApiTests;

public class CourseControllerTests
{
    CourseController controller = new CourseController();
    Guid course1Id = new Guid("b5d81570-9d7d-42d4-b352-633b8e946fba");
    [Fact]
    public void ReturnsMany()
    {
        var result = controller.GetAll();
        Assert.Equal(result.Count(), 2);
    }

    [Fact]
    public void When_GetById_ReturnsObjWithId()
    {
        var result = controller.GetCourse(course1Id);
        Assert.Equal(result.Id, course1Id);
    }


}
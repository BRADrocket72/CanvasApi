using WebApi;
using WebApi.Controllers;

namespace WebApiTests;

public class ModuleControllerTests
{
    ModuleController controller = new ModuleController();
    Guid module1Id = new Guid("248dec41-eae4-4624-a02a-fde56948d6ae");
    [Fact]
    public void ReturnsMany()
    {
        var result = controller.GetAll();
        Assert.Equal(result.Count(), 2);
    }

    [Fact]
    public void When_GetById_ReturnsObjWithId()
    {
        var result = controller.GetModule(module1Id);
        Assert.Equal(result.Id, module1Id);
    }


}
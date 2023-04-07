using System;
using Moq;
using WebApi.Controllers;
using Model;

namespace WebApiTests;


public class ModuleControllerTests
{
    private readonly Mock<IModuleRepository> _mockRepo;
    private readonly ModuleController _controller;

    public ModuleControllerTests()
    {
        _mockRepo = new Mock<IModuleRepository>();
        _controller = new ModuleController(_mockRepo.Object);
    }
    Guid module1Id = new Guid("7758e920-5e0f-4cf2-9b35-d76c1a1c3bbe");
    [Fact]
    public void ReturnsMany()
    {
        _mockRepo.Setup(x=> x.GetModules()).Returns(new List<Module>{new Module {},new Module{}});
        
        var result = _controller.GetAll();
        Assert.Equal(result.Count(), 2);
    }

    [Fact]
    public void When_GetById_ReturnsObjWithId()
    {
        _mockRepo.Setup(x => x.GetModule(It.IsAny<Guid>())).Returns(new Module { Id = module1Id });
        var result = _controller.GetModule(module1Id);
        Assert.Equal(result.Id, module1Id);
    }

}
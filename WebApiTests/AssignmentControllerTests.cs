using System;
using Moq;
using WebApi.Controllers;
using Model;

namespace WebApiTests;


public class AssignmentControllerTests
{
    private readonly Mock<IAssignmentRepository> _mockRepo;
    private readonly AssignmentController _controller;

    public AssignmentControllerTests()
    {
        _mockRepo = new Mock<IAssignmentRepository>();
        _controller = new AssignmentController(_mockRepo.Object);
    }
    Guid assignment1Id = new Guid("7758e920-5e0f-4cf2-9b35-d76c1a1c3bbe");
    [Fact]
    public void ReturnsMany()
    {
        _mockRepo.Setup(x=> x.GetAssignments()).Returns(new List<Assignment>{new Assignment {},new Assignment{}});
        
        var result = _controller.GetAll();
        Assert.Equal(result.Count(), 2);
    }

    [Fact]
    public void When_GetById_ReturnsObjWithId()
    {
        _mockRepo.Setup(x => x.GetAssignment(It.IsAny<Guid>())).Returns(new Assignment { Id = assignment1Id });
        var result = _controller.GetAssignment(assignment1Id);
        Assert.Equal(result.Id, assignment1Id);
    }

}
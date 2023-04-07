using System;
using Moq;
using WebApi.Controllers;
using Model;

namespace WebApiTests;


public class CourseControllerTests
{
    private readonly Mock<ICourseRepository> _mockRepo;
    private readonly CourseController _controller;

    public CourseControllerTests()
    {
        _mockRepo = new Mock<ICourseRepository>();
        _controller = new CourseController(_mockRepo.Object);
    }
    Guid course1Id = new Guid("7758e920-5e0f-4cf2-9b35-d76c1a1c3bbe");
    [Fact]
    public void ReturnsMany()
    {
        _mockRepo.Setup(x=> x.GetCourses()).Returns(new List<Course>{new Course {},new Course{}});
        
        var result = _controller.GetAll();
        Assert.Equal(result.Count(), 2);
    }

    [Fact]
    public void When_GetById_ReturnsObjWithId()
    {
        _mockRepo.Setup(x => x.GetCourse(It.IsAny<Guid>())).Returns(new Course { Id = course1Id });
        var result = _controller.GetCourse(course1Id);
        Assert.Equal(result.Id, course1Id);
    }

}
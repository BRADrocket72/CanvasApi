using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{

    private readonly ILogger<CourseController> _logger;

    public CourseController(ILogger<CourseController> logger)
    {
        _logger = logger;
    }
    private static Module module1 = new Module { Id = new Guid("848dec41-eae4-4624-a02a-fde56948d6ae"), Name = "module1" };
    private static Course course1 = new Course { Id = new Guid("b5d81570-9d7d-42d4-b352-633b8e946fba"), Name = "course1", Modules = new List<Module> { module1 } };
    private static Course course2 = new Course { Id = new Guid("2c87c754-a898-4c81-9065-2aaa163c66fb"), Name = "course2", };
    private static List<Course> allCourses = new List<Course> { course1, course2 };

    [HttpGet()]
    public IEnumerable<Course> GetAll()
    {
        return allCourses;
    }

    [HttpGet("/{courseId}")]
    public Course GetCourse(Guid courseId)
    {
        return allCourses.Find(x => x.Id == courseId);
    }

    [HttpPost]
    public Course CreateCourse([FromBody] Course course)
    {
        allCourses.Add(course);
        return course;
    }

    [HttpPut]
    public Course UpdateCourse([FromBody] Course course)
    {
        allCourses.Remove(course);
        allCourses.Add(course);
        return course;
    }

}

using Microsoft.AspNetCore.Mvc;
using Model;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository courseRepository;
    public CourseController(ICourseRepository courseRepository)
    {
        this.courseRepository = courseRepository;
    }


    [HttpGet()]
    public IEnumerable<Course> GetAll()
    {
        return courseRepository.GetCourses();
    }

    [HttpGet("/{courseId}")]
    public Course GetCourse(Guid courseId)
    {
        Course course = courseRepository.GetCourse(courseId);
        return course;
    }

    [HttpPost]
    public Course CreateCourse([FromBody] Course course)
    {
        return courseRepository.CreateCourse(course);
    }

    [HttpPut]
    public Course UpdateCourse([FromBody] Course course)
    {
        return courseRepository.UpdateCourse(course);
    }

}

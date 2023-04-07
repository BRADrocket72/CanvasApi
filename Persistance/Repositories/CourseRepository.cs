

using Model;

public interface ICourseRepository
{
    IEnumerable<Course> GetCourses();
    Course GetCourse(Guid courseId);
    Course CreateCourse(Course course);
    Course UpdateCourse(Course course);
    Guid DeleteCourse(Guid courseId);

}

public class CourseRepository : ICourseRepository
{
    private readonly CanvasContext canvasContext;
    public CourseRepository(CanvasContext canvasContext)
    {
        this.canvasContext = canvasContext;
    }

    public IEnumerable<Course> GetCourses()
    {
        return canvasContext.Courses.Select(x => new Course { Name = x.Name,});
    }

    public Course GetCourse(Guid courseId)
    {
        Course? course = canvasContext.Courses.First(x => x.Id == courseId);
        return course;
    }

    public Course CreateCourse(Course course)
    {
        canvasContext.Courses.Add(course);
        canvasContext.SaveChanges();
        return course;
    }

        public Course UpdateCourse(Course course)
    {
        Course updatedCourse = canvasContext.Update(course).Entity;
        canvasContext.SaveChanges();
        return updatedCourse;

    }

    public Guid DeleteCourse(Guid courseId)
    {
        Course course = canvasContext.Courses.First(x => x.Id == courseId);
        canvasContext.Courses.Remove(course);
        canvasContext.SaveChanges();
        return courseId;
    }
}
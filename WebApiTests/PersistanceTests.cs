using System;
using Moq;
using WebApi.Controllers;
using Model;

namespace WebApiTests;


public class PersistanceTests
{
    private readonly CanvasContext _mockContext;
    private readonly CourseRepository _courseRepository;
    private readonly AssignmentRepository _assignmentRepository;
    private readonly ModuleRepository _moduleRepository;

    public PersistanceTests()
    {
        _mockContext = new CanvasContext();
        _courseRepository = new CourseRepository(_mockContext);
        _assignmentRepository = new AssignmentRepository(_mockContext);
        _moduleRepository = new ModuleRepository(_mockContext);
    }


    [Fact]
    public void AddCourse_ThenRetrieveIt()
    {
        Course course = new Course { Id = Guid.NewGuid(), Name = "test" };

        var result = _courseRepository.CreateCourse(course);
        var retrievedResult = _mockContext.Courses.Where(x => x.Id == course.Id).First();
        Assert.Equal(result.Id, course.Id);
        Assert.NotNull(_mockContext.Courses.Where(x => x.Id == course.Id).First());
        Assert.Equal(course.Name, retrievedResult.Name);
    }

    [Fact]

    public void AddCourseWithModules()
    {
        Module module1 = new Module { Id = Guid.NewGuid(), Name = "module1" };
        Module module2 = new Module { Id = Guid.NewGuid(), Name = "module2" };
        Course course = new Course { Id = Guid.NewGuid(), Name = "test", Modules = new List<Module> { module1, module2 } };

        var result = _courseRepository.CreateCourse(course);
        var retrievedResult = _mockContext.Courses.Where(x => x.Id == course.Id).First();

        Assert.Equal(course.Id, retrievedResult.Id);
        Assert.Equal(2, retrievedResult.Modules.Count());
        Assert.True(retrievedResult.Modules.Contains(module1));
    }

    [Fact]
    public void Create3_Read3()
    {
        Course course1 = new Course { Id = Guid.NewGuid(), Name = "test1" };
        Course course2 = new Course { Id = Guid.NewGuid(), Name = "test2" };
        Course course3 = new Course { Id = Guid.NewGuid(), Name = "test3" };

        _courseRepository.CreateCourse(course1);
        _courseRepository.CreateCourse(course2);
        _courseRepository.CreateCourse(course3);

        var retrievedResult1 = _courseRepository.GetCourse(course1.Id);
        var retrievedResult2 = _courseRepository.GetCourse(course2.Id);
        var retrievedResult3 = _courseRepository.GetCourse(course3.Id);

        Assert.Equal(course1.Id, retrievedResult1.Id);
        Assert.Equal(course2.Id, retrievedResult2.Id);
        Assert.Equal(course3.Id, retrievedResult3.Id);
        Assert.Equal(course1.Name, retrievedResult1.Name);
        Assert.Equal(course2.Name, retrievedResult2.Name);
        Assert.Equal(course3.Name, retrievedResult3.Name);
    }

    [Fact]
    public void Create3Assignments_Delete1()
    {
        _mockContext.Assignments.RemoveRange(_mockContext.Assignments);
        _mockContext.SaveChanges();
        Assignment assignment1 = new Assignment { Id = Guid.NewGuid(), Name = "assignment1" };
        Assignment assignment2 = new Assignment { Id = Guid.NewGuid(), Name = "assignment2" };
        Assignment assignment3 = new Assignment { Id = Guid.NewGuid(), Name = "assignment3" };

        _assignmentRepository.CreateAssignment(assignment1);
        _assignmentRepository.CreateAssignment(assignment2);
        _assignmentRepository.CreateAssignment(assignment3);

        var firstGetAll = _assignmentRepository.GetAssignments().Count();
        _assignmentRepository.DeleteAssignment(assignment2.Id);
        var secondGetAll = _assignmentRepository.GetAssignments().Count();

        Assert.Equal(3, firstGetAll);
        Assert.Equal(2, secondGetAll);
    }

        [Fact]

    public void AddCourseWithModules_DeleteModule()
    {
        Module module1 = new Module { Id = Guid.NewGuid(), Name = "module1" };
        Module module2 = new Module { Id = Guid.NewGuid(), Name = "module2"};
        Course course = new Course { Id = Guid.NewGuid(), Name = "test", Modules = new List<Module> { module1, module2 } };

        var result = _courseRepository.CreateCourse(course);
        _moduleRepository.DeleteModule(module1.Id);
        var retrievedCourse = _courseRepository.GetCourse(course.Id);

        Assert.Equal(1, retrievedCourse.Modules.Count());
        Assert.True(retrievedCourse.Modules.Contains(module2));
    }
[Fact]
        public void AddModulesWithAssignment_DeleteAssignment()
    {
        Assignment assignment1 = new Assignment { Id = Guid.NewGuid(), Name = "assign1" };
        Assignment assignment2 = new Assignment { Id = Guid.NewGuid(), Name = "assign2"};
        Module module = new Module { Id = Guid.NewGuid(), Name = "test", Assignments = new List<Assignment> { assignment1, assignment2 } };

        var result = _moduleRepository.CreateModule(module);
        _assignmentRepository.DeleteAssignment(assignment1.Id);
        var retrievedModule = _moduleRepository.GetModule(module.Id);

        Assert.Equal(1, retrievedModule.Assignments.Count());
        Assert.True(retrievedModule.Assignments.Contains(assignment2));
    }

        [Fact]
    public void updateCourse()
    {
        Course course = new Course { Id = Guid.NewGuid(), Name = "test" };

        var sentCourse = _courseRepository.CreateCourse(course);
        course.Name = "test2";
        var updatedCourse = _courseRepository.UpdateCourse(course);

        Assert.Equal(course.Id, sentCourse.Id);
        Assert.Equal("test2", updatedCourse.Name);
    }
}
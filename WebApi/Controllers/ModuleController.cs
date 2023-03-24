using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : ControllerBase
{

    private readonly ILogger<ModuleController> _logger;

    public ModuleController(ILogger<ModuleController> logger)
    {
        _logger = logger;
    }
    private static Assignment assignment1 = new Assignment { Id = new Guid("7758e920-5e0f-4cf2-9b35-d76c1a1c3bbe"), Name = "homework", DueDate = DateTime.Now, Grade = 90 };
    private static Assignment assignment2 = new Assignment { Id = new Guid("1158e920-5e0f-4cf2-9b35-d76c1a1c3b33"), Name = "homework2", DueDate = DateTime.Now, Grade = 85 };
    private static Module module1 = new Module { Id = new Guid("248dec41-eae4-4624-a02a-fde56948d6ae"), Name = "module1", Assignments = new List<Assignment> { assignment1 } };
    private static Module module2 = new Module { Id = new Guid("138dec41-eae4-4624-a02a-fde56948d6aa"), Name = "module2", Assignments = new List<Assignment> { assignment2 } };
    private static List<Module> allModules = new List<Module> { module1, module2 };

    [HttpGet()]
    public IEnumerable<Module> GetAll()
    {
        return allModules;
    }

    [HttpGet("/{moduleId}")]
    public Module GetModule(Guid moduleId)
    {
        return allModules.Find(x => x.Id == moduleId);
    }

    [HttpPost]
    public Module CreateModule([FromBody] Module module)
    {
        allModules.Add(module);
        return module;
    }

    [HttpPut]
    public Module UpdateModule([FromBody] Module module)
    {
        allModules.Remove(module);
        allModules.Add(module);
        return module;
    }

}

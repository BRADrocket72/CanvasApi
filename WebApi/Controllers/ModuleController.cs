using Microsoft.AspNetCore.Mvc;
using Model;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : ControllerBase
{
    private readonly IModuleRepository moduleRepository;
    public ModuleController(IModuleRepository moduleRepository)
    {
        this.moduleRepository = moduleRepository;
    }


    [HttpGet()]
    public IEnumerable<Module> GetAll()
    {
        return moduleRepository.GetModules();
    }

    [HttpGet("/{moduleId}")]
    public Module GetModule(Guid moduleId)
    {
        Module module = moduleRepository.GetModule(moduleId);
        return module;
    }

    [HttpPost]
    public Module CreateModule([FromBody] Module module)
    {
        return moduleRepository.CreateModule(module);
    }

    [HttpPut]
    public Module UpdateModule([FromBody] Module module)
    {
        return moduleRepository.UpdateModule(module);
    }

}

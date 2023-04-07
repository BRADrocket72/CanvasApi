

using Model;

public interface IModuleRepository
{
    IEnumerable<Module> GetModules();
    Module GetModule(Guid moduleId);
    Module CreateModule(Module module);
    Module UpdateModule(Module module);
    Guid DeleteModule(Guid moduleId);

}

public class ModuleRepository : IModuleRepository
{
    private readonly CanvasContext canvasContext;
    public ModuleRepository(CanvasContext canvasContext)
    {
        this.canvasContext = canvasContext;
    }

    public IEnumerable<Module> GetModules()
    {
        return canvasContext.Modules.Select(x => new Module { Name = x.Name,Id= x.Id });
    }

    public Module GetModule(Guid moduleId)
    {
        Module? module = canvasContext.Modules.First(x => x.Id == moduleId);
        return module;
    }

    public Module CreateModule(Module module)
    {
        canvasContext.Modules.Add(module);
        canvasContext.SaveChanges();
        return module;
    }
        public Module UpdateModule(Module module)
    {
        Module updatedModule = canvasContext.Update(module).Entity;
        canvasContext.SaveChanges();
        return updatedModule;

    }

    public Guid DeleteModule(Guid moduleId)
    {
        Module module = canvasContext.Modules.First(x => x.Id == moduleId);
        canvasContext.Modules.Remove(module);
        canvasContext.SaveChanges();
        return moduleId;
    }
}
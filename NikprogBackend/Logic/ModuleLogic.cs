using NikprogServerClient.Data;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Logic
{
    public class ModuleLogic : CRUDLogic<Module>, IModuleLogic
    {
        IModuleRepository moduleRepo;
        public ModuleLogic(IModuleRepository moduleRepo)
            : base((CRUDRepository<Module>)moduleRepo)
        {
            this.moduleRepo = moduleRepo;
        }
        public IEnumerable<Module> ReadAllModulesByCourseId(string courseId)
        {
            return moduleRepo.ReadAllModulesByCourseId(courseId);
        }
    }
}

using IdentityModel;
using NikprogServerClient.Data;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Logic
{
    public class ModuleLogic : IModuleLogic
    {
        internal IModuleRepository moduleRepo;
        public ModuleLogic(IModuleRepository moduleRepo)
        {
            this.moduleRepo = moduleRepo;
        }
        public IEnumerable<Module> ReadAllModulesByCourseId(string courseId)
        {
            return moduleRepo.ReadAllModulesByCourseId(courseId);
        }
    }
}

using IdentityModel;
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

        public override void Create(Module obj)
        {
            base.Create(obj);
            obj.SequenceNum = ReadAllModulesByCourseId(obj.CourseId).Count() + 1;
            try
            {
                repo.Create(obj);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Given parameter is inadequate! SequenceNum: {obj.SequenceNum}");
            }
        }
    }
}

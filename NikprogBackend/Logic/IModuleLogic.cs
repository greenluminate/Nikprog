using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Logic
{
    public interface IModuleLogic
    {
        void Create(Module obj);
        IEnumerable<Module> ReadAllModulesByCourseId(string courseId);
    }
}
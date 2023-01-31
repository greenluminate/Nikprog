using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Logic
{
    public interface IModuleLogic
    {
        IEnumerable<Module> ReadAllModulesByCourseId(string courseId);
    }
}
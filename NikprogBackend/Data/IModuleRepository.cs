using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Data
{
    public interface IModuleRepository
    {
        IQueryable<Module> ReadAllModulesByCourseId(string courseId);
    }
}
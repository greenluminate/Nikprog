using Microsoft.EntityFrameworkCore;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Data
{
    public class ModuleRepository : CRUDRepository<Module>, IModuleRepository
    {
        public ModuleRepository(NikprogDbContext db) : base(db) { }
        public IQueryable<Module> ReadAllModulesByCourseId(string courseId)
        {
            return dbSet.Where(m => m.CourseId == courseId);
        }
    }
}

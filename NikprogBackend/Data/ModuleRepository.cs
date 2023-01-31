using IdentityModel;
using Microsoft.EntityFrameworkCore;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Data
{
    public class ModuleRepository : IModuleRepository
    {
        internal NikprogDbContext db;
        internal DbSet<Module> moduleDbSet;

        public ModuleRepository(NikprogDbContext db)
        {
            this.db = db;
            this.moduleDbSet = db.Set<Module>();
        }

        public IQueryable<Module> ReadAllModulesByCourseId(string courseId)
        {
            return moduleDbSet.Where(m => m.CourseId == courseId);
        }
    }
}

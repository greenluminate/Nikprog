using Microsoft.EntityFrameworkCore;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Data
{
    public class MaterialInfoRepository : CRUDRepository<MaterialInfo>, IMaterialInfoRepository
    {
        public MaterialInfoRepository(NikprogDbContext db) : base(db) { }

        public IQueryable<MaterialInfo> ReadAllMaterialInfosByModuleId(string moduleId)
        {
            return dbSet.Where(material => material.ModuleId == moduleId);
        }
    }
}

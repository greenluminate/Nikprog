using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Data
{
    public interface IMaterialInfoRepository
    {
        IQueryable<MaterialInfo> ReadAllMaterialInfosByModuleId(string moduleId);
    }
}
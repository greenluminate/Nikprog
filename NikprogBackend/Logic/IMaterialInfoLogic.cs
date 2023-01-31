using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Logic
{
    public interface IMaterialInfoLogic
    {
        IEnumerable<MaterialInfo> ReadAllMaterialInfosByModuleId(string moduleId);
    }
}
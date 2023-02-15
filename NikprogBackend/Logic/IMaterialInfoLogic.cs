using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Logic
{
    public interface IMaterialInfoLogic
    {
        void Create(MaterialInfo obj);
        IEnumerable<MaterialInfo> ReadAllMaterialInfosByModuleId(string moduleId);
    }
}
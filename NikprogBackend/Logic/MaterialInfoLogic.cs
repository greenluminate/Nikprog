using NikprogServerClient.Data;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Logic
{
    public class MaterialInfoLogic : IMaterialInfoLogic
    {
        internal IMaterialInfoRepository materialInfoRepo;
        public MaterialInfoLogic(IMaterialInfoRepository materialInfoRepo)
        {
            this.materialInfoRepo = materialInfoRepo;
        }
        public IEnumerable<MaterialInfo> ReadAllMaterialInfosByModuleId(string moduleId)
        {
            return materialInfoRepo.ReadAllMaterialInfosByModuleId(moduleId);
        }
    }
}

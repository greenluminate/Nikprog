using NikprogServerClient.Data;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Logic
{
    public class MaterialInfoLogic : CRUDLogic<MaterialInfo>, IMaterialInfoLogic
    {
        IMaterialInfoRepository materialInfoRepo;
        public MaterialInfoLogic(IMaterialInfoRepository materialInfoRepo)
            : base((CRUDRepository<MaterialInfo>)materialInfoRepo)
        {
            this.materialInfoRepo = materialInfoRepo;
        }
        public IEnumerable<MaterialInfo> ReadAllMaterialInfosByModuleId(string moduleId)
        {
            return materialInfoRepo.ReadAllMaterialInfosByModuleId(moduleId);
        }
    }
}

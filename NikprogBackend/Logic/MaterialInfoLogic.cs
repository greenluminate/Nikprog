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

        public override void Create(MaterialInfo obj)
        {
            base.Create(obj);
            obj.SequenceNum = ReadAllMaterialInfosByModuleId(obj.ModuleId).Count() + 1;
            try
            {
                repo.Create(obj);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Given parameter is inadequate! SequenceNum: {obj.SequenceNum}");
            }
        }
    }
}

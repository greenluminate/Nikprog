using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialInfoController : GPPDController<MaterialInfo>
    {

        IMaterialInfoLogic materialLogic;
        public MaterialInfoController(ICRUDLogic<MaterialInfo> logic, IMaterialInfoLogic materialLogic)
            : base(logic)
        {
            this.materialLogic = materialLogic;
        }

        [HttpGet("[action]/{moduleId}")]
        public IEnumerable<MaterialInfo> GetMaterialInfosByModuleId(string moduleId)
        {
            return materialLogic.ReadAllMaterialsByModuleId(moduleId);
        }
    }
}

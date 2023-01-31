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
        public MaterialInfoController(ICRUDLogic<MaterialInfo> logic)
            : base(logic)
        {
        }
    }
}

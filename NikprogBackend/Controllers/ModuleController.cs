using Microsoft.AspNetCore.Mvc;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : GPPDController<Module>
    {
        public ModuleController(ICRUDLogic<Module> logic)
            : base(logic)
        {
        }
    }
}

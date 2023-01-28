using Microsoft.AspNetCore.Mvc;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentInfoController : GPPDController<DocumentInfo>
    {
        public DocumentInfoController(ICRUDLogic<DocumentInfo> logic)
            : base(logic)
        {
        }
    }
}

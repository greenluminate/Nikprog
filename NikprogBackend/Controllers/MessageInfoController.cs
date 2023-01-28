using Microsoft.AspNetCore.Mvc;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageInfoController : GPPDController<MessageInfo>
    {
        public MessageInfoController(ICRUDLogic<MessageInfo> logic)
            : base(logic)
        {
        }
    }
}

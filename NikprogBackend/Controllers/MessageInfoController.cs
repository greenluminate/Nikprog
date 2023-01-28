using NikprogBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net.Sockets;
using NikprogBackend.Models.CourseMaterials;
using NikprogServerClient.Models.CourseMaterials;
using NikprogServerClient.Logic;

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

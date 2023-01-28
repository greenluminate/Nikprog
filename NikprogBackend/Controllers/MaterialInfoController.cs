using NikprogBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net.Sockets;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Controllers
{
    //[Authorize]
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

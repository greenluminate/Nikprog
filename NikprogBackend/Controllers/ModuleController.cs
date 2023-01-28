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
    public class ModuleController : GPPDController<Module>
    {
        public ModuleController(ICRUDLogic<Module> logic)
            : base(logic)
        {
        }
    }
}

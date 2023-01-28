using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net.Sockets;
using NikprogServerClient.Models.CourseMaterials;
using NikprogServerClient.Logic;

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

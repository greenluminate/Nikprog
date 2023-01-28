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
    public class VideoInfoController : GPPDController<VideoInfo>
    {
        public VideoInfoController(ICRUDLogic<VideoInfo> logic)
            : base(logic)
        {
        }
    }
}

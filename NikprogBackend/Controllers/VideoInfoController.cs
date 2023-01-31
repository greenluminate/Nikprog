using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Controllers
{
    [Authorize]
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

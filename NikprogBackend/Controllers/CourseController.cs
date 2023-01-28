using Microsoft.AspNetCore.Mvc;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : GPPDController<Course>
    {
        public CourseController(ICRUDLogic<Course> logic)
            : base(logic)
        {
        }
    }
}

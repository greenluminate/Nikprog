using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikprogServerClient.Logic;
using NikprogServerClient.Models.CourseMaterials;

namespace NikprogServerClient.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : GPPDController<Module>
    {
        IModuleLogic moduleLogic;
        public ModuleController(ICRUDLogic<Module> logic, IModuleLogic moduleLogic)
            : base(logic)
        {
            this.moduleLogic = moduleLogic;
        }

        [HttpGet("[action]/{courseId}")]
        public IEnumerable<Module> GetModulesByCourseId(string courseId)
        {
            return moduleLogic.ReadAllModulesByCourseId(courseId);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Teacher")]
        public override void Post([FromBody] Module entity)
        {
            moduleLogic.Create(entity);

            List<string> connectedTabelsNames = typeof(Module)
                .GetProperties()
                .Where(prop => prop.PropertyType.AssemblyQualifiedName
                    .Contains("ICollection"))
                .Select(prop => prop.Name.TrimEnd('s')).ToList();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NikprogServerClient.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NikprogServerClient.Controllers
{
    [Authorize]
    [ApiController]
    public class GPPDController<TEntity> : ControllerBase where TEntity : class
    {
        ICRUDLogic<TEntity> logic;

        public GPPDController(ICRUDLogic<TEntity> logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public TEntity Get(string id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        [Authorize(Roles = "Amind, Techer")]
        public void Post([FromBody] TEntity entity)
        {
            logic.Create(entity);

            List<string> connectedTabelsNames = typeof(TEntity)
                .GetProperties()
                .Where(prop => prop.PropertyType.AssemblyQualifiedName
                    .Contains("ICollection"))
                .Select(prop => prop.Name.TrimEnd('s')).ToList();
        }

        [HttpPut]
        [Authorize(Roles = "Amind, Techer")]
        public void Put([FromBody] TEntity entity)
        {
            logic.Update(entity);

            List<string> connectedTabelsNames = typeof(TEntity)
                .GetProperties()
                .Where(prop => prop.PropertyType.AssemblyQualifiedName
                    .Contains("ICollection"))
                .Select(prop => prop.Name.TrimEnd('s')).ToList();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Amind, Techer")]
        public void Delete(string id)
        {
            var entityToDelete = logic.Read(id);
            logic.Delete(id);

            List<string> connectedTabelsNames = typeof(TEntity)
                .GetProperties()
                .Where(prop => prop.PropertyType.AssemblyQualifiedName
                    .Contains("ICollection"))
                .Select(prop => prop.Name.TrimEnd('s')).ToList();
        }
    }
}

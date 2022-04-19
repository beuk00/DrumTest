using DrumAPI.Repositories;
using DrumLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DrumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerCrudBase<T, R> : ControllerBase where T : BaseModel where R : Repository<T>
    {
        protected R repository;

        public ControllerCrudBase(R r)
        {
            repository = r;
        }

        // read
        [HttpGet]
        public virtual async Task<IActionResult> ListAll()
        {
            return Ok(await repository.ListAll());
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            return Ok(await repository.GetById(id));
        }

        // delete
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var entity = await repository.DeleteById(id);
            if (entity == null)
            {
                return NotFound(); // 404
            }

            return Ok(entity);
        }

        // create
        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            T item = await repository.Create(entity);
            if (item == null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetById", new { id = entity.Id }, entity);
        }

        // update
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update([FromRoute] int id, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            T e = await repository.Update(entity);
            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }
    }
}

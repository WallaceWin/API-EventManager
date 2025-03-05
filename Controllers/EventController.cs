using EventManager.Data;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    [ApiController]
    [Route("api")]
    public class EventController : ControllerBase
    {
        [HttpGet("Events")]
        public async Task<IActionResult> Get(
            [FromServices] AppDataContext context
            )
        {
            try
            {
                var result = await context.Events.AsNoTracking().Include(x => x.Locality).ToListAsync();
        
                if (result == null) return NotFound(result);

                return Ok(result);
            }
            catch (Exception)
            {
                
                return BadRequest();
            }
        }

        [HttpGet("Events/{id:guid}")]
        public async Task<IActionResult> GetById(
            [FromServices] AppDataContext context,
            [FromRoute] Guid id
            )
        {
            try
            {
                var result = await context.Events.AsNoTracking().Include(x => x.Locality).FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return NotFound(result);

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("Events")]
        public async Task<IActionResult> Post(
            [FromServices] AppDataContext context,
            [FromBody] EventModel model
            )
        {
            try
            {
                var result = await context.Events.AddAsync(model);
                await context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut("Events/{id:guid}")]
        public async Task<IActionResult> Put(
            [FromServices] AppDataContext context,
            [FromBody] EventModel model,
            [FromRoute] Guid id
            )
        {
            try
            {
                var result = await context.Events.FirstOrDefaultAsync();
                if (result == null) return NotFound();
                result.EventName = model.EventName;
                result.EventDate = model.EventDate;
                result.LocalityId = model.LocalityId;

                context.Update(result);
                await context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("Events/{id:guid}")]
        public async Task<IActionResult> Delete(
            [FromServices] AppDataContext context,
            [FromRoute] Guid id
            )
        {
            try
            {
                var result = await context.Events.FirstOrDefaultAsync();
                if (result == null) return NotFound();

                context.Remove(result);
                await context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}

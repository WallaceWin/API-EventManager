using EventManager.Data;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EventManager.Controllers
{
    [ApiController]
    [Route("api")]
    public class LocalityController : ControllerBase
    {
        [HttpGet("localities")]
        public async Task<IActionResult> Get(
            [FromServices] AppDataContext context
            )
        {
            try
            {
                var result = await context.Localities.AsNoTracking().Include(x => x.Events).ToListAsync();
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("localities/{id:guid}")]
        public async Task<IActionResult> GetById(
            [FromServices] AppDataContext context,
            [FromRoute] Guid id
            )
        {
            try
            {
                var result = await context.Localities.AsNoTracking().Include(x => x.Events).FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("localities")]
        public async Task<IActionResult> Post(
            [FromServices] AppDataContext context,
            [FromBody] LocalityModel model
            )
        {
            try
            {
                var result = await context.Localities.AddAsync(new LocalityModel
                {
                    LocalityName = model.LocalityName,
                    Ender = model.Ender
                });

                await context.SaveChangesAsync();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("localities/{id:guid}")]
        public async Task<IActionResult> Update(
            [FromServices] AppDataContext context,
            [FromRoute] Guid id,
            [FromBody] LocalityModel model
            )
        {
            try
            {
                var result = await context.Localities.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return NotFound();
                result.LocalityName = model.LocalityName;
                result.Ender = model.Ender;
                context.Update(result);
                await context.SaveChangesAsync();

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("localities/{id:guid}")]
        public async Task<IActionResult> Delete(
            [FromServices] AppDataContext context,
            [FromRoute] Guid id
            )
        {
            try
            {
                var result = await context.Localities.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return NotFound();

                context.Remove(result);
                await context.SaveChangesAsync();

                return Ok("Deletado com sucesso");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

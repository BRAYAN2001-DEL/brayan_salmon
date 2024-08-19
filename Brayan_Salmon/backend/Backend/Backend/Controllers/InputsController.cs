using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InputsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Input>>> GetInputs()
        {
            return await _context.Inputs.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Input>> PostInput(Input input)
        {
            _context.Inputs.Add(input);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInputs), new { id = input.Id }, input);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInput(int id, Input input)
        {
            if (id != input.Id)
            {
                return BadRequest();
            }

            _context.Entry(input).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InputExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInput(int id)
        {
            var input = await _context.Inputs.FindAsync(id);
            if (input == null)
            {
                return NotFound();
            }

            _context.Inputs.Remove(input);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool InputExists(int id)
        {
            return _context.Inputs.Any(e => e.Id == id);
        }
    }
}

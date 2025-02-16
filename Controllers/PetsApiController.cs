using KeepetFinal.Data;
using KeepetFinal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeepetFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            var pets = await _context.Pets.Include(p => p.User).ToListAsync();
            return Ok(pets);
        }

        // ✅ GET: api/pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();

            return Ok(pet);
        }

        // ✅ POST: api/pets
        [HttpPost]
        public async Task<ActionResult<Pet>> CreatePet(Pet pet)
        {
            pet.UserId = "3f661225-cad5-494b-afb9-a12df73e04c5";
            pet.User = await _context.Users.FindAsync(pet.UserId);
            pet.SpecialNeeds = "غذا";

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }

        // ✅ PUT: api/pets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, Pet pet)
        {
            if (id != pet.Id) return BadRequest();

            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: api/pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

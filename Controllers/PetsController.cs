using KeepetFinal.Data;
using KeepetFinal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeepetFinal.Controllers
{
    namespace KeepetFinal.Controllers
    {
        public class PetsController : Controller
        {
            private readonly ApplicationDbContext _context;

            public PetsController(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Index()
            {
                var pets = await _context.Pets.Include(p => p.User).ToListAsync();
                return View(pets);
            }

            public async Task<IActionResult> Details(int id)
            {
                var pet = await _context.Pets.FindAsync(id);
                if (pet == null) return NotFound();

                return View(pet);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            //[ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Pet pet)
            {
                pet.UserId = "3f661225-cad5-494b-afb9-a12df73e04c5";
                pet.User = await _context.Users.FindAsync(pet.UserId);
                pet.SpecialNeeds = "غذا";
                //if (ModelState.IsValid)
                //{
                    _context.Add(pet);
                    await _context.SaveChangesAsync();
                //    return RedirectToAction(nameof(Index));
                //}
                return View(pet);
            }

            public async Task<IActionResult> Edit(int id)
            {
                var pet = await _context.Pets.FindAsync(id);
                if (pet == null) return NotFound();

                return View(pet);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Pet pet)
            {
                if (id != pet.Id) return BadRequest();

                if (ModelState.IsValid)
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(pet);
            }

            public async Task<IActionResult> Delete(int id)
            {
                var pet = await _context.Pets.FindAsync(id);
                if (pet == null) return NotFound();

                return View(pet);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var pet = await _context.Pets.FindAsync(id);
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
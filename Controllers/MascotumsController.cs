using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppScaffolding.Models;

namespace AppScaffolding.Controllers
{
    public class MascotumsController : Controller
    {
        private readonly AppDbContext _context;

        public MascotumsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Mascotums
        public async Task<IActionResult> Index()
           
        {
            var AppDbContext = _context.Mascota.Include(c => c.Id);
            return View(await _context.Mascota.ToListAsync());
        }

        // GET: Mascotums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascotum == null)
            {
                return NotFound();
            }

            return View(mascotum);
        }

        // GET: Mascotums/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Mascota, "Id", "Id");
            return View();
        }

        // POST: Mascotums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Especie,Raza,UsuarioId")] Mascotum mascotum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Mascota, "Id", "Id", mascotum.Id);
            return View(mascotum);
        }

        // GET: Mascotums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Mascota, "Id", "Id", mascotum.Id);
            return View(mascotum);
        }

        // POST: Mascotums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Especie,Raza,UsuarioId")] Mascotum mascotum)
        {
            if (id != mascotum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotumExists(mascotum.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Mascota, "Id", "Id", mascotum.Id);
            return View(mascotum);
        }

        // GET: Mascotums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascotum == null)
            {
                return NotFound();
            }

            return View(mascotum);
        }

        // POST: Mascotums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum != null)
            {
                _context.Mascota.Remove(mascotum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotumExists(int id)
        {
            return _context.Mascota.Any(e => e.Id == id);
        }
    }
}

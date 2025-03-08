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
    public class AdopcionsController : Controller
    {
        private readonly AppDbContext _context;

        public AdopcionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Adopcions
        public async Task<IActionResult> Index()

        {
            var AppDbContext = _context.Adopcions.Include(c => c.Id);
            return View(await _context.Adopcions.ToListAsync());
        }

        // GET: Adopcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopcions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return View(adopcion);
        }

        // GET: Adopcions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adopcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaAdopcion,UsuarioId,MascotaId")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adopcion);
        }

        // GET: Adopcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopcions.FindAsync(id);
            if (adopcion == null)
            {
                return NotFound();
            }
            return View(adopcion);
        }

        // POST: Adopcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaAdopcion,UsuarioId,MascotaId")] Adopcion adopcion)
        {
            if (id != adopcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adopcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdopcionExists(adopcion.Id))
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
            return View(adopcion);
        }

        // GET: Adopcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopcions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return View(adopcion);
        }

        // POST: Adopcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopcion = await _context.Adopcions.FindAsync(id);
            if (adopcion != null)
            {
                _context.Adopcions.Remove(adopcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdopcionExists(int id)
        {
            return _context.Adopcions.Any(e => e.Id == id);
        }
    }
}

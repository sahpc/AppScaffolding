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
    public class SeguimientoesController : Controller
    {
        private readonly AppDbContext _context;

        public SeguimientoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Seguimientoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seguimientos.ToListAsync());
        }

        // GET: Seguimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguimiento = await _context.Seguimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seguimiento == null)
            {
                return NotFound();
            }

            return View(seguimiento);
        }

        // GET: Seguimientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seguimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaVista,Comentario,EstadoMascota,AdopcionId")] Seguimiento seguimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seguimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seguimiento);
        }

        // GET: Seguimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguimiento = await _context.Seguimientos.FindAsync(id);
            if (seguimiento == null)
            {
                return NotFound();
            }
            return View(seguimiento);
        }

        // POST: Seguimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaVisita,Comentario,EstadoMascota,AdopcionId")] Seguimiento seguimiento)
        {
            if (id != seguimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seguimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeguimientoExists(seguimiento.Id))
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
            return View(seguimiento);
        }

        // GET: Seguimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seguimiento = await _context.Seguimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seguimiento == null)
            {
                return NotFound();
            }

            return View(seguimiento);
        }

        // POST: Seguimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seguimiento = await _context.Seguimientos.FindAsync(id);
            if (seguimiento != null)
            {
                _context.Seguimientos.Remove(seguimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeguimientoExists(int id)
        {
            return _context.Seguimientos.Any(e => e.Id == id);
        }
    }
}

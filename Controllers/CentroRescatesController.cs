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
    public class CentroRescatesController : Controller
    {
        private readonly AppDbContext _context;

        public CentroRescatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CentroRescates
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentroRescates.ToListAsync());
        }

        // GET: CentroRescates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroRescate = await _context.CentroRescates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroRescate == null)
            {
                return NotFound();
            }

            return View(centroRescate);
        }

        // GET: CentroRescates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentroRescates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Telefono,Responsable")] CentroRescate centroRescate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroRescate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centroRescate);
        }

        // GET: CentroRescates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroRescate = await _context.CentroRescates.FindAsync(id);
            if (centroRescate == null)
            {
                return NotFound();
            }
            return View(centroRescate);
        }

        // POST: CentroRescates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Telefono,Responsable")] CentroRescate centroRescate)
        {
            if (id != centroRescate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centroRescate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroRescateExists(centroRescate.Id))
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
            return View(centroRescate);
        }

        // GET: CentroRescates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroRescate = await _context.CentroRescates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroRescate == null)
            {
                return NotFound();
            }

            return View(centroRescate);
        }

        // POST: CentroRescates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centroRescate = await _context.CentroRescates.FindAsync(id);
            if (centroRescate != null)
            {
                _context.CentroRescates.Remove(centroRescate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroRescateExists(int id)
        {
            return _context.CentroRescates.Any(e => e.Id == id);
        }
    }
}

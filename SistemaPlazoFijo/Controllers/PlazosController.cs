using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaPlazoFijo.Datos;
using SistemaPlazoFijo.Models;

namespace SistemaPlazoFijo.Controllers
{
    public class PlazosController : Controller
    {
        private readonly BaseDeDatos _context;

        public PlazosController(BaseDeDatos context)
        {
            _context = context;
        }

        // GET: Plazos
        public async Task<IActionResult> Index()
        {
              return _context.Plazos != null ? 
                          View(await _context.Plazos.ToListAsync()) :
                          Problem("Entity set 'BaseDeDatos.Plazos'  is null.");
        }

        // GET: Plazos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plazos == null)
            {
                return NotFound();
            }

            var plazo = await _context.Plazos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plazo == null)
            {
                return NotFound();
            }

            return View(plazo);
        }

        // GET: Plazos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plazos/Create
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Monto,Dias,FechaIngreso,FechaRetiro")] Plazo plazo)
        {

            if (ModelState.IsValid)
            {
                if (plazo.Dias != 0)
                {
                    plazo.setFechaIngreso();
                    plazo.setFechaRetiro();
                }
                _context.Add(plazo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                
            }
            return View(plazo);
        }

        // GET: Plazos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plazos == null)
            {
                return NotFound();
            }

            var plazo = await _context.Plazos.FindAsync(id);
            if (plazo == null)
            {
                return NotFound();
            }
            return View(plazo);
        }

        // POST: Plazos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Monto,Dias,FechaIngreso,FechaRetiro")] Plazo plazo)
        {
            if (id != plazo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plazo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlazoExists(plazo.Id))
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
            return View(plazo);
        }

        // GET: Plazos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plazos == null)
            {
                return NotFound();
            }

            var plazo = await _context.Plazos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plazo == null)
            {
                return NotFound();
            }

            return View(plazo);
        }

        // POST: Plazos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plazos == null)
            {
                return Problem("Entity set 'BaseDeDatos.Plazos'  is null.");
            }
            var plazo = await _context.Plazos.FindAsync(id);
            if (plazo != null)
            {
                _context.Plazos.Remove(plazo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlazoExists(int id)
        {
          return (_context.Plazos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asistencia_rips_APP.Data;
using asistencia_rips_APP.Models;

namespace asistencia_rips_APP.Controllers
{
    public class SubdireccionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubdireccionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subdireccion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subdireccion.Include(s => s.Direccion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subdireccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdireccionClass = await _context.Subdireccion
                .Include(s => s.Direccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subdireccionClass == null)
            {
                return NotFound();
            }

            return View(subdireccionClass);
        }

        // GET: Subdireccion/Create
        public IActionResult Create()
        {
            ViewData["DireccionId"] = new SelectList(_context.Direccion, "Id", "Nombre");
            return View();
        }

        // POST: Subdireccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,DireccionId,is_Active")] SubdireccionClass subdireccionClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subdireccionClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DireccionId"] = new SelectList(_context.Direccion, "Id", "Nombre", subdireccionClass.DireccionId);
            return View(subdireccionClass);
        }

        // GET: Subdireccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdireccionClass = await _context.Subdireccion.FindAsync(id);
            if (subdireccionClass == null)
            {
                return NotFound();
            }
            ViewData["DireccionId"] = new SelectList(_context.Direccion, "Id", "Nombre", subdireccionClass.DireccionId);
            return View(subdireccionClass);
        }

        // POST: Subdireccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,DireccionId,is_Active")] SubdireccionClass subdireccionClass)
        {
            if (id != subdireccionClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subdireccionClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubdireccionClassExists(subdireccionClass.Id))
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
            ViewData["DireccionId"] = new SelectList(_context.Direccion, "Id", "Nombre", subdireccionClass.DireccionId);
            return View(subdireccionClass);
        }

        // GET: Subdireccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdireccionClass = await _context.Subdireccion
                .Include(s => s.Direccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subdireccionClass == null)
            {
                return NotFound();
            }

            return View(subdireccionClass);
        }

        // POST: Subdireccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subdireccionClass = await _context.Subdireccion.FindAsync(id);
            _context.Subdireccion.Remove(subdireccionClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubdireccionClassExists(int id)
        {
            return _context.Subdireccion.Any(e => e.Id == id);
        }
    }
}

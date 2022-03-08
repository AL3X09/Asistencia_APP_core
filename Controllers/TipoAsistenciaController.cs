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
    public class TipoAsistenciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoAsistenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoAsistencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipoasistencia.ToListAsync());
        }

        // GET: TipoAsistencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAsistenciaClass = await _context.Tipoasistencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoAsistenciaClass == null)
            {
                return NotFound();
            }

            return View(tipoAsistenciaClass);
        }

        // GET: TipoAsistencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAsistencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,is_Active")] TipoAsistenciaClass tipoAsistenciaClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAsistenciaClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAsistenciaClass);
        }

        // GET: TipoAsistencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAsistenciaClass = await _context.Tipoasistencia.FindAsync(id);
            if (tipoAsistenciaClass == null)
            {
                return NotFound();
            }
            return View(tipoAsistenciaClass);
        }

        // POST: TipoAsistencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,is_Active")] TipoAsistenciaClass tipoAsistenciaClass)
        {
            if (id != tipoAsistenciaClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAsistenciaClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAsistenciaClassExists(tipoAsistenciaClass.Id))
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
            return View(tipoAsistenciaClass);
        }

        // GET: TipoAsistencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAsistenciaClass = await _context.Tipoasistencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoAsistenciaClass == null)
            {
                return NotFound();
            }

            return View(tipoAsistenciaClass);
        }

        // POST: TipoAsistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAsistenciaClass = await _context.Tipoasistencia.FindAsync(id);
            _context.Tipoasistencia.Remove(tipoAsistenciaClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAsistenciaClassExists(int id)
        {
            return _context.Tipoasistencia.Any(e => e.Id == id);
        }
    }
}

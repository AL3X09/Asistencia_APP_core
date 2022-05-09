using asistencia_rips_APP.Data;
using asistencia_rips_APP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asistencia_rips_APP.Controllers
{
    [Authorize]
    public class EstadoTramiteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadoTramiteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: estadoTramite
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoTramite.ToListAsync());
        }

        // GET: estadoTramite/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTramiteClass = await _context.EstadoTramite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoTramiteClass == null)
            {
                return NotFound();
            }

            return View(estadoTramiteClass);
        }

        // GET: estadoTramite/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estadoTramite/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fecha,is_active")] EstadoTramiteClass estadoTramiteClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoTramiteClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoTramiteClass);
        }

        // GET: estadoTramite/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTramiteClass = await _context.EstadoTramite.FindAsync(id);
            if (estadoTramiteClass == null)
            {
                return NotFound();
            }
            return View(estadoTramiteClass);
        }

        // POST: estadoTramite/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fecha,is_Active")] EstadoTramiteClass estadoTramiteClass)
        {
            if (id != estadoTramiteClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoTramiteClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoTramiteClassExists(estadoTramiteClass.Id))
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
            return View(estadoTramiteClass);
        }

        // GET: estadoTramite/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoTramiteClass = await _context.EstadoTramite.FirstOrDefaultAsync(m => m.Id == id);
            if (estadoTramiteClass == null)
            {
                return NotFound();
            }

            return View(estadoTramiteClass);
        }

        // POST: estadoTramite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoTramiteClass = await _context.EstadoTramite.FindAsync(id);
            _context.EstadoTramite.Remove(estadoTramiteClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoTramiteClassExists(int id)
        {
            return _context.EstadoTramite.Any(e => e.Id == id);
        }


        

    }
}

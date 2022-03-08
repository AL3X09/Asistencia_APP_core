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
    public class DireccionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DireccionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Direccion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Direccion.ToListAsync());
        }

        // GET: Direccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionClass = await _context.Direccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccionClass == null)
            {
                return NotFound();
            }

            return View(direccionClass);
        }

        // GET: Direccion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Direccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,is_Active")] DireccionClass direccionClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccionClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(direccionClass);
        }

        // GET: Direccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionClass = await _context.Direccion.FindAsync(id);
            if (direccionClass == null)
            {
                return NotFound();
            }
            return View(direccionClass);
        }

        // POST: Direccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,is_Active")] DireccionClass direccionClass)
        {
            if (id != direccionClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccionClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionClassExists(direccionClass.Id))
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
            return View(direccionClass);
        }

        // GET: Direccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccionClass = await _context.Direccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccionClass == null)
            {
                return NotFound();
            }

            return View(direccionClass);
        }

        // POST: Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccionClass = await _context.Direccion.FindAsync(id);
            _context.Direccion.Remove(direccionClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionClassExists(int id)
        {
            return _context.Direccion.Any(e => e.Id == id);
        }
    }
}

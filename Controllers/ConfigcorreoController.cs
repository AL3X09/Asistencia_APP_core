using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asistencia_rips_APP.Models;
using asistencia_rips_APP.Data;

namespace asistencia_rips_APP.Controllers
{
    public class ConfigcorreoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigcorreoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Configcorreo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Configcorreo.ToListAsync());
        }

        // GET: Configcorreo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configCorreoClass = await _context.Configcorreo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configCorreoClass == null)
            {
                return NotFound();
            }

            return View(configCorreoClass);
        }

        // GET: Configcorreo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Configcorreo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Host,Port,UseSSL,is_Active")] ConfigCorreoClass configCorreoClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configCorreoClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configCorreoClass);
        }

        // GET: Configcorreo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configCorreoClass = await _context.Configcorreo.FindAsync(id);
            if (configCorreoClass == null)
            {
                return NotFound();
            }
            return View(configCorreoClass);
        }

        // POST: Configcorreo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Host,Port,UseSSL,is_Active")] ConfigCorreoClass configCorreoClass)
        {
            if (id != configCorreoClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configCorreoClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigCorreoClassExists(configCorreoClass.Id))
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
            return View(configCorreoClass);
        }

        // GET: Configcorreo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configCorreoClass = await _context.Configcorreo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (configCorreoClass == null)
            {
                return NotFound();
            }

            return View(configCorreoClass);
        }

        // POST: Configcorreo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configCorreoClass = await _context.Configcorreo.FindAsync(id);
            _context.Configcorreo.Remove(configCorreoClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigCorreoClassExists(int id)
        {
            return _context.Configcorreo.Any(e => e.Id == id);
        }
    }
}

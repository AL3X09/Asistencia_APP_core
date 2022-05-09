using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asistencia_rips_APP.Data;
using asistencia_rips_APP.Models;
using Microsoft.AspNetCore.Authorization;

namespace asistencia_rips_APP.Controllers
{
    [Authorize]
    public class TemaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TemaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tema
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tema.ToListAsync());
        }

        // GET: listar
        [Route("api/Tema/Listar")]
        [Produces("application/json")]
        public IActionResult Listar(string name)
        {
            var listatemas =  _context.Tema.Where(t=>t.is_Active == true && t.Nombre.Contains(name)).ToList();
            /*var listatemas;          
                listatemas = _context.Tema.ToListAsync();*/

            if (listatemas == null)
            {
                return NotFound();
            }
            return Ok(listatemas);
        }

        // GET: listar
        [Route("api/Tema/BuscarId")]
        [Produces("application/json")]
        public IActionResult ListarById(string id)
        {
            var listatema = _context.Tema.Where(t => t.is_Active == true && t.Id.Equals(id)).ToList();

            if (listatema == null)
            {
                return NotFound();
            }
            return Ok(listatema);
        }

        // GET: Tema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temaClass = await _context.Tema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temaClass == null)
            {
                return NotFound();
            }

            return View(temaClass);
        }

        // GET: Tema/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tema/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,is_Active")] TemaClass temaClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temaClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temaClass);
        }

        // GET: Tema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temaClass = await _context.Tema.FindAsync(id);
            if (temaClass == null)
            {
                return NotFound();
            }
            return View(temaClass);
        }

        // POST: Tema/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,is_Active")] TemaClass temaClass)
        {
            if (id != temaClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temaClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemaClassExists(temaClass.Id))
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
            return View(temaClass);
        }

        // GET: Tema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temaClass = await _context.Tema
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temaClass == null)
            {
                return NotFound();
            }

            return View(temaClass);
        }

        // POST: Tema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temaClass = await _context.Tema.FindAsync(id);
            _context.Tema.Remove(temaClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemaClassExists(int id)
        {
            return _context.Tema.Any(e => e.Id == id);
        }
    }
}

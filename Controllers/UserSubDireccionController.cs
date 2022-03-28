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
    public class UserSubDireccionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserSubDireccionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserSubDireccion
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserSubdireccion.Include(u => u.Subdireccion).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserSubDireccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubDireccionClass = await _context.UserSubdireccion
                .Include(s => s.Subdireccion)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSubDireccionClass == null)
            {
                return NotFound();
            }

            return View(userSubDireccionClass);
        }

        // GET: UserSubDireccion/Create
        public IActionResult Create()
        {
            
            ViewData["SubdireccionData"] = new SelectList(_context.Subdireccion.Where(e => e.is_Active == true), "Id", "Nombre");
            ViewData["UserData"] = new SelectList(from x in _context.Users select new { x.Id, FullName = x.FirstName + " " + x.LastName }, "Id", "FullName");
            //ViewData["SubdireccionId"] = new SelectList(_context.Subdireccion, "Id", "Id");
            return View();
        }

        // POST: UserSubDireccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserSubDireccionClass userSubDireccionClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSubDireccionClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubdireccionData"] = new SelectList(_context.Subdireccion.Where(e => e.is_Active == true), "Id", "Nombre", userSubDireccionClass.SubdireccionId);
            ViewData["UserData"] = new SelectList(from x in _context.Users select new { x.Id, FullName = x.FirstName + " " + x.LastName }, "Id", "FullName", userSubDireccionClass.UserId);
            return View(userSubDireccionClass);
        }

        // GET: UserSubDireccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubDireccionClass = await _context.UserSubdireccion.FindAsync(id);
            if (userSubDireccionClass == null)
            {
                return NotFound();
            }
            ViewData["SubdireccionData"] = new SelectList(_context.Subdireccion.Where(e => e.is_Active == true), "Id", "Nombre");
            ViewData["UserData"] = new SelectList(from x in _context.Users select new { x.Id, FullName = x.FirstName + " " + x.LastName }, "Id", "FullName");
            //ViewData["SubdireccionId"] = new SelectList(_context.Subdireccion, "Id", "Id", userSubDireccionClass.SubdireccionId);
            return View(userSubDireccionClass);
        }

        // POST: UserSubDireccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserSubDireccionClass userSubDireccionClass)
        {
            if (id != userSubDireccionClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSubDireccionClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSubDireccionClassExists(userSubDireccionClass.Id))
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
            ViewData["SubdireccionData"] = new SelectList(_context.Subdireccion.Where(e => e.is_Active == true), "Id", "Nombre");
            ViewData["UserData"] = new SelectList(from x in _context.Users select new { x.Id, FullName = x.FirstName + " " + x.LastName }, "Id", "FullName");
            //ViewData["SubdireccionId"] = new SelectList(_context.Subdireccion, "Id", "Id", userSubDireccionClass.SubdireccionId);
            return View(userSubDireccionClass);
        }

        // GET: UserSubDireccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSubDireccionClass = await _context.UserSubdireccion
                .Include(u => u.Subdireccion)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSubDireccionClass == null)
            {
                return NotFound();
            }

            return View(userSubDireccionClass);
        }

        // POST: UserSubDireccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSubDireccionClass = await _context.UserSubdireccion.FindAsync(id);
            _context.UserSubdireccion.Remove(userSubDireccionClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSubDireccionClassExists(int id)
        {
            return _context.UserSubdireccion.Any(e => e.Id == id);
        }
    }
}

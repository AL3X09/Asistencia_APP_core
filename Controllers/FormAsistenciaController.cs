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
    public class FormAsistenciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormAsistenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormAsistencia
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Formasistencia.Include(f => f.Tema).Include(f => f.TipoAsistencia).Include(et => et.EstadoTramite).Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> listaporusaurio(String nombreusuario)
        {
            var applicationDbContext = _context.Formasistencia.Include(f => f.Tema).Include(f => f.TipoAsistencia).Include(et => et.EstadoTramite).Include(f => f.User).Where(u => u.User.UserName == nombreusuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FormAsistencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formAsistenciaClass = await _context.Formasistencia
                .Include(f => f.Tema)
                .Include(f => f.TipoAsistencia)
                .Include(et => et.EstadoTramite)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formAsistenciaClass == null)
            {
                return NotFound();
            }

            return View(formAsistenciaClass);
        }

        // GET: FormAsistencia/Create
        public IActionResult Create_old()
        {
            ViewData["TemaId"] = new SelectList(_context.Tema, "Id", "Nombre");
            ViewData["TipoAsistenciaId"] = new SelectList(_context.Tipoasistencia, "Id", "Nombre");
            ViewData["EstadoTramiteId"] = new SelectList(_context.EstadoTramite, "Id", "Nombre");
            ViewData["Userdata"] = (from x in _context.Users select new { x.Id, FullName = x.FirstName + " " + x.LastName }, "Id", "FullName");
            return View();
        }
        public IActionResult Create(String nombreusuario)
        {
            ViewData["consec"] =  (_context.Formasistencia.Count()+1);
            ViewData["TemaId"] = new SelectList(_context.Tema.Where(t => t.is_Active == true), "Id", "Nombre");
            ViewData["TipoAsistenciaId"] = new SelectList(_context.Tipoasistencia.Where(p => p.is_Active == true), "Id", "Nombre");
            ViewData["EstadoTramiteId"] = new SelectList(_context.EstadoTramite.Where(e => e.is_Active == true), "Id", "Nombre");


            ViewData["iduser"] = (from x in _context.Users
                                    where x.UserName == nombreusuario
                                    select x.Id).FirstOrDefault();
            ViewData["fullname"] = (from x in _context.Users
                                    where x.UserName == nombreusuario
                                    select x.FirstName + " " + x.LastName
                                   ).FirstOrDefault();
            return View();
        }

        // POST: FormAsistencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Consec,Fecha,Nombres_contacto,Apellidos_contacto,Datos_contacto,Acciones,Compromisos,Firma,TemaId,TipoAsistenciaId,EstadoTramiteId,UserId,is_Active")] FormAsistenciaClass formAsistenciaClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formAsistenciaClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TemaId"] = new SelectList(_context.Tema.Where(t => t.is_Active == true), "Id", "Nombre", formAsistenciaClass.TemaId);
            ViewData["TipoAsistenciaId"] = new SelectList(_context.Tipoasistencia.Where(p => p.is_Active == true), "Id", "Nombre", formAsistenciaClass.TipoAsistenciaId);
            ViewData["EstadoTramiteId"] = new SelectList(_context.EstadoTramite.Where(e => e.is_Active == true), "Id", "Nombre", formAsistenciaClass.EstadoTramiteId);

            ViewData["iduser"] = (from x in _context.Users
                                  where x.Id == formAsistenciaClass.UserId
                                  select x.Id).FirstOrDefault();
            ViewData["fullname"] = (from x in _context.Users
                                    where x.Id == formAsistenciaClass.UserId
                                    select x.FirstName + " " + x.LastName
                                   ).FirstOrDefault();

            return View(formAsistenciaClass);
        }

        // GET: FormAsistencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formAsistenciaClass = await _context.Formasistencia.FindAsync(id);
            if (formAsistenciaClass == null)
            {
                return NotFound();
            }
            ViewData["TemaId"] = new SelectList(_context.Tema.Where(e => e.is_Active == true), "Id", "Nombre", formAsistenciaClass.TemaId);
            ViewData["TipoAsistenciaId"] = new SelectList(_context.Tipoasistencia.Where(e => e.is_Active == true), "Id", "Nombre", formAsistenciaClass.TipoAsistenciaId);
            ViewData["EstadoTramiteId"] = new SelectList(_context.EstadoTramite.Where(e => e.is_Active == true), "Id", "Nombre", formAsistenciaClass.EstadoTramiteId);
            ViewData["iduser"] = (from x in _context.Users
                                  where x.Id == formAsistenciaClass.UserId
                                  select x.Id).FirstOrDefault();
            ViewData["fullname"] = (from x in _context.Users
                                    where x.Id == formAsistenciaClass.UserId
                                    select x.FirstName + " " + x.LastName
                                   ).FirstOrDefault();

            return View(formAsistenciaClass);
        }

        // POST: FormAsistencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Consec,Fecha,Nombres_contacto,Apellidos_contacto,Datos_contacto,Acciones,Compromisos,Firma,TemaId,TipoAsistenciaId,EstadoTramiteId,UserId,is_Active")] FormAsistenciaClass formAsistenciaClass)
        {
            if (id != formAsistenciaClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formAsistenciaClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormAsistenciaClassExists(formAsistenciaClass.Id))
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
            ViewData["TemaId"] = new SelectList(_context.Tema.Where(e => e.is_Active == true), "Id", "Nombre", formAsistenciaClass.TemaId);
            ViewData["TipoAsistenciaId"] = new SelectList(_context.Tipoasistencia.Where(e => e.is_Active == true), "Id", "Nombre", formAsistenciaClass.TipoAsistenciaId);
            ViewData["EstadoTramiteId"] = new SelectList(_context.EstadoTramite.Where(e => e.is_Active == true), "Id", "Nombre", formAsistenciaClass.EstadoTramiteId);
            ViewData["iduser"] = (from x in _context.Users
                                  where x.Id == formAsistenciaClass.UserId
                                  select x.Id).FirstOrDefault();
            ViewData["fullname"] = (from x in _context.Users
                                    where x.Id == formAsistenciaClass.UserId
                                    select x.FirstName + " " + x.LastName
                                   ).FirstOrDefault();

            return View(formAsistenciaClass);
        }

        // GET: FormAsistencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formAsistenciaClass = await _context.Formasistencia
                .Include(f => f.Tema)
                .Include(f => f.TipoAsistencia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formAsistenciaClass == null)
            {
                return NotFound();
            }

            return View(formAsistenciaClass);
        }

        // POST: FormAsistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formAsistenciaClass = await _context.Formasistencia.FindAsync(id);
            _context.Formasistencia.Remove(formAsistenciaClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormAsistenciaClassExists(int id)
        {
            return _context.Formasistencia.Any(e => e.Id == id);
        }
    }
}

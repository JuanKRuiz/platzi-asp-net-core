using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using platzi_asp_net_core.Models;

namespace platzi_asp_net_core.Controllers
{
    public class EscuelaController : Controller
    {
        private readonly EscuelaContext _context;

        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: Escuela
        public async Task<IActionResult> Index()
        {
            return View(await _context.Escuelas.ToListAsync());
        }

        // GET: Escuela/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuela = await _context.Escuelas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escuela == null)
            {
                return NotFound();
            }

            return View(escuela);
        }

        // GET: Escuela/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escuela/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AñoDeCreación,Pais,Ciudad,Dirección,TipoEscuela,Id,Nombre")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escuela);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escuela);
        }

        // GET: Escuela/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuela = await _context.Escuelas.FindAsync(id);
            if (escuela == null)
            {
                return NotFound();
            }
            return View(escuela);
        }

        // POST: Escuela/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AñoDeCreación,Pais,Ciudad,Dirección,TipoEscuela,Id,Nombre")] Escuela escuela)
        {
            if (id != escuela.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escuela);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscuelaExists(escuela.Id))
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
            return View(escuela);
        }

        // GET: Escuela/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escuela = await _context.Escuelas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escuela == null)
            {
                return NotFound();
            }

            return View(escuela);
        }

        // POST: Escuela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var escuela = await _context.Escuelas.FindAsync(id);
            _context.Escuelas.Remove(escuela);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscuelaExists(string id)
        {
            return _context.Escuelas.Any(e => e.Id == id);
        }
    }
}

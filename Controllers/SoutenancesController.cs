using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PfeApp.Models;

namespace Pfeapp2.Controllers
{
    public class SoutenancesController : Controller
    {
        private readonly SoutenanceContext _context;

        public SoutenancesController(SoutenanceContext context)
        {
            _context = context;
        }

        // GET: Soutenances
        public async Task<IActionResult> Index()
        {
            var soutenanceContext = _context.Soutenance.Include(s => s.Pfe).Include(s => s.President).Include(s => s.Rapporteur);
            return View(await soutenanceContext.ToListAsync());
        }

        // GET: Soutenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soutenance = await _context.Soutenance
                .Include(s => s.Pfe)
                .Include(s => s.President)
                .Include(s => s.Rapporteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soutenance == null)
            {
                return NotFound();
            }

            return View(soutenance);
        }

        // GET: Soutenances/Create
        public IActionResult Create()
        {
            ViewData["PfeId"] = new SelectList(_context.Pfe, "Id", "Title");
            ViewData["PresidentId"] = new SelectList(_context.Enseignant, "Id", "Nom");
            ViewData["RapporteurId"] = new SelectList(_context.Enseignant, "Id", "Nom");
            return View();
        }

        // POST: Soutenances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Heure,PfeId,PresidentId,RapporteurId")] Soutenance soutenance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soutenance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PfeId"] = new SelectList(_context.Pfe, "Id", "Title", soutenance.PfeId);
            ViewData["PresidentId"] = new SelectList(_context.Enseignant, "Id", "Nom", soutenance.PresidentId);
            ViewData["RapporteurId"] = new SelectList(_context.Enseignant, "Id", "Nom", soutenance.RapporteurId);
            return View(soutenance);
        }

        // GET: Soutenances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soutenance = await _context.Soutenance.FindAsync(id);
            if (soutenance == null)
            {
                return NotFound();
            }
            ViewData["PfeId"] = new SelectList(_context.Pfe, "Id", "Title", soutenance.PfeId);
            ViewData["PresidentId"] = new SelectList(_context.Enseignant, "Id", "Nom", soutenance.PresidentId);
            ViewData["RapporteurId"] = new SelectList(_context.Enseignant, "Id", "Nom", soutenance.RapporteurId);
            return View(soutenance);
        }

        // POST: Soutenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Heure,PfeId,PresidentId,RapporteurId")] Soutenance soutenance)
        {
            if (id != soutenance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soutenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoutenanceExists(soutenance.Id))
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
            ViewData["PfeId"] = new SelectList(_context.Pfe, "Id", "Title", soutenance.PfeId);
            ViewData["PresidentId"] = new SelectList(_context.Enseignant, "Id", "Nom", soutenance.PresidentId);
            ViewData["RapporteurId"] = new SelectList(_context.Enseignant, "Id", "Nom", soutenance.RapporteurId);
            return View(soutenance);
        }

        // GET: Soutenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soutenance = await _context.Soutenance
                .Include(s => s.Pfe)
                .Include(s => s.President)
                .Include(s => s.Rapporteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soutenance == null)
            {
                return NotFound();
            }

            return View(soutenance);
        }

        // POST: Soutenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soutenance = await _context.Soutenance.FindAsync(id);
            if (soutenance != null)
            {
                _context.Soutenance.Remove(soutenance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoutenanceExists(int id)
        {
            return _context.Soutenance.Any(e => e.Id == id);
        }
    }
}

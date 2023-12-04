using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PfeApp.Models;
using Pfeapp2.Models;

namespace Pfeapp2.Controllers
{
  
    public class Pfe_etudiantController : Controller
    {
        private readonly SoutenanceContext _context;

        public Pfe_etudiantController(SoutenanceContext context)
        {
            _context = context;
        }

        // GET: Pfe_etudiant
        public async Task<IActionResult> Index( )
        {

            var soutenanceContext = from etudiant in _context.Pfe_etudiant
                                    join pfe in _context.Pfe on etudiant.PfeId equals pfe.Id
                                    join s in _context.Soutenance on etudiant.PfeId equals s.Id
                                    join societe in _context.Societe on pfe.SocieteID equals societe.Id
                                    join encadrant in _context.Enseignant on pfe.EncadrantID equals encadrant.Id
                                    join president in _context.Enseignant on s.PresidentId equals president.Id
                                    join rapporteur in _context.Enseignant on s.RapporteurId equals rapporteur.Id
                                    select new EtudPfe
                                    {
                                        Id = etudiant.Id,
                                        EtudiantId = etudiant.Etudiant.Id,
                                        Etudiant = etudiant.Etudiant.NomPrenom,
                                        PfeTitle = etudiant.Pfe.Title,
                                        Societe = societe.Lib,
                                        Encadrant = encadrant.Nom,
                                        President = president.Nom,
                                        Rapporteur = rapporteur.Nom
                                    };
            var uniqueSoutenanceContext = soutenanceContext
                                           .GroupBy(x => x.EtudiantId)
                                           .Select(group => group.First());

            return View(await uniqueSoutenanceContext.ToListAsync());
        

        }

        // GET: Pfe_etudiant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe_etudiant = await _context.Pfe_etudiant
                .Include(p => p.Etudiant)
                .Include(p => p.Pfe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pfe_etudiant == null)
            {
                return NotFound();
            }

            return View(pfe_etudiant);
        }

        // GET: Pfe_etudiant/Create
        public IActionResult Create()
        {
            ViewData["EtudiantID"] = new SelectList(_context.Etudiant, "Id", "Nom");
            ViewData["PfeId"] = new SelectList(_context.Pfe, "Id", "Title");
            return View();
        }

        // POST: Pfe_etudiant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PfeId,EtudiantID")] Pfe_etudiant pfe_etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pfe_etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantID"] = new SelectList(_context.Etudiant, "Id", "Nom", pfe_etudiant.EtudiantID);
            ViewData["PfeId"] = new SelectList(_context.Pfe, "Id", "Title", pfe_etudiant.PfeId);
            return View(pfe_etudiant);
        }

        // GET: Pfe_etudiant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe_etudiant = await _context.Pfe_etudiant.FindAsync(id);
            if (pfe_etudiant == null)
            {
                return NotFound();
            }
            ViewData["EtudiantID"] = new SelectList(_context.Etudiant, "Id", "Nom", pfe_etudiant.EtudiantID);
            ViewData["PfeId"] = new SelectList(_context.Pfe, "Id", "Title", pfe_etudiant.PfeId);
            return View(pfe_etudiant);
        }

        // POST: Pfe_etudiant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PfeId,EtudiantID")] Pfe_etudiant pfe_etudiant)
        {
            if (id != pfe_etudiant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pfe_etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pfe_etudiantExists(pfe_etudiant.Id))
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
            ViewData["EtudiantID"] = new SelectList(_context.Etudiant, "Id", "Nom", pfe_etudiant.EtudiantID);
            ViewData["PfeId"] = new SelectList(_context.Pfe, "Id", "Title", pfe_etudiant.PfeId);
            return View(pfe_etudiant);
        }

        // GET: Pfe_etudiant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe_etudiant = await _context.Pfe_etudiant
                .Include(p => p.Etudiant)
                .Include(p => p.Pfe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pfe_etudiant == null)
            {
                return NotFound();
            }

            return View(pfe_etudiant);
        }

        // POST: Pfe_etudiant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pfe_etudiant = await _context.Pfe_etudiant.FindAsync(id);
            if (pfe_etudiant != null)
            {
                _context.Pfe_etudiant.Remove(pfe_etudiant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Pfe_etudiantExists(int id)
        {
            return _context.Pfe_etudiant.Any(e => e.Id == id);
        }
    }
}

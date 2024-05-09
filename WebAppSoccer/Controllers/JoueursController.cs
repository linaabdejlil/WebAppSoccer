using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppSoccer.Data;
using WebAppSoccer.Models;

namespace WebAppSoccer.Controllers
{
    public class JoueursController : Controller
    {
        private readonly SoccerDbContext _context;

        public JoueursController(SoccerDbContext context)
        {
            _context = context;
        }

        // GET: Joueurs
        public async Task<IActionResult> Index()
        {
            var soccerDbContext = _context.Joueurs.Include(j => j.Club);
            return View(await soccerDbContext.ToListAsync());
        }

        // GET: Joueurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs
                .Include(j => j.Club)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // GET: Joueurs/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "LibClub");
            return View();
        }

        // POST: Joueurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,DateN,Num,ClubId")] Joueur joueur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joueur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "LibClub", joueur.ClubId);
            return View(joueur);
        }

        // GET: Joueurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "LibClub", joueur.ClubId);
            return View(joueur);
        }

        // POST: Joueurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,DateN,Num,ClubId")] Joueur joueur)
        {
            if (id != joueur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joueur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoueurExists(joueur.Id))
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
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "LibClub", joueur.ClubId);
            return View(joueur);
        }

        // GET: Joueurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs
                .Include(j => j.Club)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // POST: Joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joueur = await _context.Joueurs.FindAsync(id);
            if (joueur != null)
            {
                _context.Joueurs.Remove(joueur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JoueurExists(int id)
        {
            return _context.Joueurs.Any(e => e.Id == id);
        }
    }
}

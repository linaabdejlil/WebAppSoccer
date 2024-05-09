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
    public class ParticipersController : Controller
    {
        private readonly SoccerDbContext _context;

        public ParticipersController(SoccerDbContext context)
        {
            _context = context;
        }

        // GET: Participers
        public async Task<IActionResult> Index()
        {
            var soccerDbContext = _context.Participers.Include(p => p.Joueur).Include(p => p.Match);
            return View(await soccerDbContext.ToListAsync());
        }

        // GET: Participers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participer = await _context.Participers
                .Include(p => p.Joueur)
                .Include(p => p.Match)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participer == null)
            {
                return NotFound();
            }

            return View(participer);
        }

        // GET: Participers/Create
        public IActionResult Create()
        {
            ViewData["JoueurId"] = new SelectList(_context.Joueurs, "Id", "Id");
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id");
            return View();
        }

        // POST: Participers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchId,JoueurId")] Participer participer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JoueurId"] = new SelectList(_context.Joueurs, "Id", "Id", participer.JoueurId);
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", participer.MatchId);
            return View(participer);
        }

        // GET: Participers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participer = await _context.Participers.FindAsync(id);
            if (participer == null)
            {
                return NotFound();
            }
            ViewData["JoueurId"] = new SelectList(_context.Joueurs, "Id", "Id", participer.JoueurId);
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", participer.MatchId);
            return View(participer);
        }

        // POST: Participers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchId,JoueurId")] Participer participer)
        {
            if (id != participer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticiperExists(participer.Id))
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
            ViewData["JoueurId"] = new SelectList(_context.Joueurs, "Id", "Id", participer.JoueurId);
            ViewData["MatchId"] = new SelectList(_context.Matches, "Id", "Id", participer.MatchId);
            return View(participer);
        }

        // GET: Participers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participer = await _context.Participers
                .Include(p => p.Joueur)
                .Include(p => p.Match)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participer == null)
            {
                return NotFound();
            }

            return View(participer);
        }

        // POST: Participers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participer = await _context.Participers.FindAsync(id);
            if (participer != null)
            {
                _context.Participers.Remove(participer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticiperExists(int id)
        {
            return _context.Participers.Any(e => e.Id == id);
        }
    }
}

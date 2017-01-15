using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using footballstats.Data;
using footballstats.Models;

namespace footballstats.Controllers
{
    public class DomainTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DomainTeamsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: DomainTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.DomainTeam.ToListAsync());
        }

        // GET: DomainTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domainTeam = await _context.DomainTeam.SingleOrDefaultAsync(m => m.Id == id);
            if (domainTeam == null)
            {
                return NotFound();
            }

            return View(domainTeam);
        }

        // GET: DomainTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DomainTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GoalsLost,GoalsWon,LossesDuringAddedTime,LossesDuringMainTime,Points,Title,WinsDuringAddedTime,WinsDuringMainTime")] DomainTeam domainTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domainTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(domainTeam);
        }

        // GET: DomainTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domainTeam = await _context.DomainTeam.SingleOrDefaultAsync(m => m.Id == id);
            if (domainTeam == null)
            {
                return NotFound();
            }
            return View(domainTeam);
        }

        // POST: DomainTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GoalsLost,GoalsWon,LossesDuringAddedTime,LossesDuringMainTime,Points,Title,WinsDuringAddedTime,WinsDuringMainTime")] DomainTeam domainTeam)
        {
            if (id != domainTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domainTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomainTeamExists(domainTeam.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(domainTeam);
        }

        // GET: DomainTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domainTeam = await _context.DomainTeam.SingleOrDefaultAsync(m => m.Id == id);
            if (domainTeam == null)
            {
                return NotFound();
            }

            return View(domainTeam);
        }

        // POST: DomainTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var domainTeam = await _context.DomainTeam.SingleOrDefaultAsync(m => m.Id == id);
            _context.DomainTeam.Remove(domainTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DomainTeamExists(int id)
        {
            return _context.DomainTeam.Any(e => e.Id == id);
        }
    }
}

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
            const int mainTime = 60;

            const int winDuringMainTimePoints = 5;
            const int winDuringAddedTimePoints = 3;
            const int lossDuringAddedTimePoints = 2;
            const int lossDuringMainTimePoints = 1;

            var teams = from t in _context.DomainTeam select t;

            foreach (var team in teams)
            {
                team.GoalsWon = _context
                    .Team
                    .Where(t => t.Title == team.Title)
                    .SelectMany(t => t.GoalsRecord.Goals)
                    .Count();

                team.GoalsLost = _context
                    .Game
                    .Where(game => game.Teams.Any(t => t.Title == team.Title))
                    .SelectMany(game => game.Teams.Where(t => t.Title != team.Title))
                    .SelectMany(t => t.GoalsRecord.Goals)
                    .Count();

                var gamesCount = _context.Game.Where(g => g.Teams.Any(t => t.Title == team.Title)).Count();

                team.WinsDuringMainTime = _context
                    .Game
                    .Where(g =>
                        g.Teams.Any(t => t.Title == team.Title) && (
                        g.Teams.Where(t => t.Title == team.Title).SelectMany(t => t.GoalsRecord.Goals).Count() >
                        g.Teams.Where(t => t.Title != team.Title).SelectMany(t => t.GoalsRecord.Goals).Count()) &&
                        g.Teams.Where(t => t.Title == team.Title).SelectMany(t => t.GoalsRecord.Goals).Max(x => x.Time).TotalMinutes <= mainTime
                    ).Count();

                team.WinsDuringAddedTime = _context
                    .Game
                    .Where(g =>
                        g.Teams.Any(t => t.Title == team.Title) && (
                        g.Teams.Where(t => t.Title == team.Title).SelectMany(t => t.GoalsRecord.Goals).Count() >
                        g.Teams.Where(t => t.Title != team.Title).SelectMany(t => t.GoalsRecord.Goals).Count()) &&
                        g.Teams.Where(t => t.Title == team.Title).SelectMany(t => t.GoalsRecord.Goals).Max(x => x.Time).TotalMinutes > mainTime
                    ).Count();

                team.LossesDuringMainTime = _context
                    .Game
                    .Where(g =>
                        g.Teams.Any(t => t.Title == team.Title) && (
                        g.Teams.Where(t => t.Title == team.Title).SelectMany(t => t.GoalsRecord.Goals).Count() <
                        g.Teams.Where(t => t.Title != team.Title).SelectMany(t => t.GoalsRecord.Goals).Count()) &&
                        g.Teams.Where(t => t.Title != team.Title).SelectMany(t => t.GoalsRecord.Goals).Max(x => x.Time).TotalMinutes <= mainTime
                    ).Count();

                team.LossesDuringAddedTime = _context
                    .Game
                    .Where(g =>
                        g.Teams.Any(t => t.Title == team.Title) && (
                        g.Teams.Where(t => t.Title == team.Title).SelectMany(t => t.GoalsRecord.Goals).Count() <
                        g.Teams.Where(t => t.Title != team.Title).SelectMany(t => t.GoalsRecord.Goals).Count()) &&
                        g.Teams.Where(t => t.Title != team.Title).SelectMany(t => t.GoalsRecord.Goals).Max(x => x.Time).TotalMinutes > mainTime
                    ).Count();

                team.Points = team.WinsDuringMainTime * winDuringMainTimePoints
                    + team.WinsDuringAddedTime * winDuringAddedTimePoints
                    + team.LossesDuringAddedTime * lossDuringAddedTimePoints
                    + team.LossesDuringMainTime * lossDuringMainTimePoints;

            }

            foreach (var team in  teams)
            {
                team.Place = teams.Where(t => t.Points > team.Points).Count() + 1;
            }
            teams = teams.OrderByDescending(t => t.Points);
            return View(await teams.ToListAsync());
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
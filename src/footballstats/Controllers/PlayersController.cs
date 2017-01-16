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
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            foreach (var player in _context.Player)
            {
                player.Goals = _context
                    .Game
                    .SelectMany(g => g.Teams.Where(t => t.Title == player.Team))
                    .SelectMany(a => a.GoalsRecord.Goals)
                    .Where(b => b.PlayerNr == player.Number)
                    .Count();

                player.Passes = _context
                    .Game
                    .SelectMany(c => c.Teams.Where(d => d.Title == player.Team))
                    .SelectMany(e => e.GoalsRecord.Goals)
                    .SelectMany(f => f.Passers)
                    .Where(h => h.Nr == player.Number)
                    .Count();

                var playersTeamGames = _context.Game
                    .SelectMany(g => g.Teams)
                    .Where(t => t.Title == player.Team);
                
                player.GamesPlayedInMainTeam = playersTeamGames
                    //.Where(t => t.MainPlayersRecord.PlayersNrs.Any(n => n.Nr == player.Number)).Count();
                    .SelectMany(t => t.MainPlayersRecord.PlayersNrs)
                    .Where(n => n.Nr == player.Number).Count();

                //player.GamesPlayed = playersTeamGames
                //    .Where(t =>
                //        t.MainPlayersRecord.PlayersNrs.Any(n => n.Nr == player.Number) ||
                //        t.ChangeRecord.Changes.Any(c => c.PlayerIn == player.Number)
                //    ).Count();

                //player.YellowCards = playersTeamGames
                //    .Count(g => g.PenaltiesRecord.Penalties.Where(p => p.PlayerNr == player.Number).Count() == 1);

                //player.RedCards = playersTeamGames
                //    .Count(g => g.PenaltiesRecord.Penalties.Where(p => p.PlayerNr == player.Number).Count() == 2);
            }
            return View(await _context
                .Player
                .OrderByDescending(p => p.Goals)
                .ThenByDescending(z => z.Passes).ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,Number,Role,Team")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,Number,Role,Team")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.SingleOrDefaultAsync(m => m.Id == id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}

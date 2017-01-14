using footballstats.Data;
using footballstats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace footballstats.Utils
{
    public class Repository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save(GameRecord json)
        {
            if (Exists(json.Spele))
                return;

            var game = Create(json.Spele);
            
            _context.Add(game);
        }

        public bool Exists(Game json) =>
            _context.Game.Any(g =>  
                json.Date == g.Date &&
                json.Place == g.Place &&
                json.Teams.All(jsonTeam => g.Teams.Any(
                    dbteam => dbteam.Title == jsonTeam.Title)));

        public Game Create(Game json)
        {
            return new Game
            {
                Date = json.Date,
                Place = json.Place,
                Spectators = json.Spectators
            };
        }

    }
}

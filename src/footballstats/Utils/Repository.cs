using footballstats.Data;
using footballstats.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace footballstats.Utils
{
    public class Repository
    {

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        {
                return;

            _context.Add(game);
        }

        public bool Exists(Game json) =>
            _context.Game.Any(g =>  
                json.Date == g.Date &&
                json.Place == g.Place &&
                json.Teams.All(jsonTeam => g.Teams.Any(
                    dbteam => dbteam.Title == jsonTeam.Title)));


    }
}

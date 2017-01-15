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
        ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save(Game game)
        {
            if (GameExists(game))
                return;

            //var lineReferees = game.LineReferees;
            //game.LineReferees = new List<Referee>();
            //foreach (var referee in lineReferees)
            //    game.LineReferees.Add(GetOrCreate(referee));

            game.MainReferee = GetOrCreate(game.MainReferee);

            //var composedGame = Create(game);

            _context.Add(game);
        }
        
        public void DetachAll()
        {
            foreach (var dbEntityEntry in _context.ChangeTracker.Entries())
                if (dbEntityEntry.Entity != null)
                    dbEntityEntry.State = EntityState.Detached;
        }

        public Referee GetOrCreate(Referee r) =>
            _context
                .Referee
                .AsNoTracking()
                .FirstOrDefault(x =>
                x.Firstname == r.Firstname &&
                x.Lastname == r.Lastname)
            ?? r;


        public bool GameExists(Game json) =>
            _context.Game.Any(g =>
                json.Date == g.Date &&
                json.Place == g.Place &&
                json.Teams.All(jsonTeam => g.Teams.Any(
                    dbteam => dbteam.Title == jsonTeam.Title)));

        //public Game Create(Game json) => new Game
        //{
        //    Date = json.Date,
        //    Place = json.Place,
        //    Spectators = json.Spectators,
        //    LineReferees = json.LineReferees,
        //    MainReferee = json.MainReferee
        //};

    }
}

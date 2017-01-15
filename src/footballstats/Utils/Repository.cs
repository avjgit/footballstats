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
        public void Save(Game game)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-footballstats-c97e58ed-833c-4919-a857-dfbc2f48b102;Trusted_Connection=True;MultipleActiveResultSets=true;");

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                if (GameExists(context, game))
                    return;

                var lineReferees = game.LineReferees;
                game.LineReferees = new List<Referee>();
                foreach (var referee in lineReferees)
                {
                    game.LineReferees.Add(GetOrCreate(context, referee));
                }

                game.MainReferee = GetOrCreate(context, game.MainReferee);

                //var composedGame = Create(game);

                context.Add(game);
                context.SaveChanges();
            }
        }

        //public void DetachAll()
        //{
        //    foreach (var dbEntityEntry in _context.ChangeTracker.Entries())
        //        if (dbEntityEntry.Entity != null)
        //            dbEntityEntry.State = EntityState.Detached;
        //}

        public Referee GetOrCreate(ApplicationDbContext _context, Referee r)
        {
            var referee = _context
                .Referee
                .AsNoTracking()
                .FirstOrDefault(x =>
                x.Firstname == r.Firstname &&
                x.Lastname == r.Lastname);

            if (referee != null)
            {
                _context.Entry(referee).State = EntityState.Modified;
                return referee;
            }
            return r;
        }

        public bool GameExists(ApplicationDbContext _context, Game json) =>
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

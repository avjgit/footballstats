using footballstats.Data;
using footballstats.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace footballstats.Utils
{
    public class Repository
    {
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;

        public Repository()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-footballstats-c97e58ed-833c-4919-a857-dfbc2f48b102;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        public void Save(Game game)
        {
            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                if (GameExists(context, game))
                    return;

                game.LineReferees = GetIfExists(context, game.LineReferees);
                game.MainReferee = GetIfExists(context, game.MainReferee);

                context.Add(game);
                context.SaveChanges();
            }
        }

        public List<T> GetIfExists<T>(ApplicationDbContext _context, List<T> objList)
        {
            var listWithIds = new List<T>();
            objList.ForEach(obj => listWithIds.Add(GetIfExists(_context, (dynamic)obj)));
            return listWithIds;
        }

        public Referee GetIfExists(ApplicationDbContext _context, Referee r)
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
    }
}

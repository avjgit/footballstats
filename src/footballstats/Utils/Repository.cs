using footballstats.Data;
using footballstats.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace footballstats.Utils
{
    public static class ParsingManager
    {

        public static void Parse(IFormFile file)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-footballstats-c97e58ed-833c-4919-a857-dfbc2f48b102;Trusted_Connection=True;MultipleActiveResultSets=true;");

            using (var fileStream = new StreamReader(file.OpenReadStream()))
            {
                var gameRecord = JsonConvert.DeserializeObject<GameRecord>(fileStream.ReadToEnd());

                using (var context = new ApplicationDbContext(optionsBuilder.Options))
                {
                    new Parser(context).ParseAndSave(gameRecord.Spele);
                }
            }
        }
    }

    public class Parser
    {
        ApplicationDbContext context;

        public Parser(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void ParseAndSave(Game game)
        {
            if (GameExists(game))
                return;

            game.LineReferees = GetIfExists(game.LineReferees);
            game.MainReferee = GetIfExists(game.MainReferee);
            //game.Teams = GetIfExists(game.Teams);

            context.Add(game);
            context.SaveChanges();
        }

        public List<T> GetIfExists<T>(List<T> objList)
        {
            var listWithIds = new List<T>();
            objList.ForEach(obj => listWithIds.Add(GetIfExists((dynamic)obj)));
            return listWithIds;
        }

        public Referee GetIfExists(Referee r)
        {
            var referee = context
                .Referee
                .AsNoTracking()
                .FirstOrDefault(x =>
                x.Firstname == r.Firstname &&
                x.Lastname == r.Lastname);

            if (referee != null)
            {
                context.Entry(referee).State = EntityState.Modified;
                return referee;
            }
            return r;
        }

        public bool GameExists(Game json) =>
            context.Game.Any(g =>
                json.Date == g.Date &&
                json.Place == g.Place &&
                json.Teams.All(jsonTeam => g.Teams.Any(
                    dbteam => dbteam.Title == jsonTeam.Title)));


        public static TimeSpan GetTime(string timeRecord)
        {
            var time = timeRecord.Split(':');
            int hours = 0;
            int minutes = int.Parse(time[0]);
            int seconds = int.Parse(time[1]);
            return new TimeSpan(hours, minutes, seconds);
        }
    }
}

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

            foreach (var team in game.Teams)
            {
                foreach (var player in team.AllPLayersRecord.Players)
                {
                    player.Team = team.Title;
                    AddIfNotExists(player);
                }
                context.SaveChanges();
                team.AllPLayersRecord = new PlayersList();

                if (team.GoalsRecord != null)
                {
                    foreach (var goal in team.GoalsRecord.Goals)
                    {
                        goal.Time = GetTime(goal.TimeRecord);
                    }
                }

                if (team.PenaltiesRecord != null)
                {
                    foreach (var penalty in team.PenaltiesRecord.Penalties)
                    {
                        penalty.Time = GetTime(penalty.TimeRecord);
                    }
                }

                if (team.ChangeRecord != null)
                {
                    foreach (var change in team.ChangeRecord.Changes)
                    {
                        change.Time = GetTime(change.TimeRecord);
                    }
                }

                AddDomainTeamIfNotExits(team);

            }

            context.Add(game);
            context.SaveChanges();
        }

        public List<T> GetIfExists<T>(List<T> objList)
        {
            var listWithIds = new List<T>();
            objList.ForEach(obj => listWithIds.Add(GetIfExists((dynamic)obj)));
            return listWithIds;
        }

        public void AddDomainTeamIfNotExits(Team jsonTeam)
        {
            if (!context.DomainTeam.Any(t => t.Title == jsonTeam.Title))
            {
                var team = new DomainTeam
                {
                    Title = jsonTeam.Title
                };
                context.Add(team);
            }
        }
        public void AddIfNotExists(Player jsonEntity)
        {
            var player = GetIfExists(jsonEntity);
            if (player.Id == 0)
                context.Add(player);
        }

        public Player GetIfExists(Player jsonEntity)
        {
            var dbEntity = context
                .Player
                .AsNoTracking()
                .FirstOrDefault(x =>
                    x.Firstname == jsonEntity.Firstname &&
                    x.Lastname == jsonEntity.Lastname &&
                    x.Number == jsonEntity.Number &&
                    x.Team == jsonEntity.Team);

            if (dbEntity != null)
            {
                context.Entry(dbEntity).State = EntityState.Modified;
                return dbEntity;
            }

            return jsonEntity;
        }

        public Team GetIfExists(Team jsonEntity)
        {
            var dbEntity = context
                .Team
                .AsNoTracking()
                .FirstOrDefault(x => x.Title == jsonEntity.Title);

            if (dbEntity != null)
            {
                context.Entry(dbEntity).State = EntityState.Modified;
                return dbEntity;
            }

            return jsonEntity;
        }

        public Referee GetIfExists(Referee jsonEntity)
        {
            var dbEntity = context
                .Referee
                .AsNoTracking()
                .FirstOrDefault(x =>
                x.Firstname == jsonEntity.Firstname &&
                x.Lastname == jsonEntity.Lastname);

            if (dbEntity != null)
            {
                context.Entry(dbEntity).State = EntityState.Modified;
                return dbEntity;
            }

            return jsonEntity;
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

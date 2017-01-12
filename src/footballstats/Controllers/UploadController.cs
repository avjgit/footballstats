using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using footballstats.Models;
using footballstats.Data;
using Newtonsoft.Json.Converters;

namespace footballstats.Controllers
{
    public class UploadController : Controller
    {
        private readonly ApplicationDbContext _context;

        private IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ICollection<IFormFile> files)
        {
            var fileContent = String.Empty;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new StreamReader(file.OpenReadStream()))
                    {
                        GameRecord gameRecord;
                        fileContent = fileStream.ReadToEnd();
                        gameRecord = JsonConvert.DeserializeObject<GameRecord>(fileContent);

                        if (ModelState.IsValid)
                        {
                            //foreach (var game in games)
                            //{
                            //var refereeExists = _context
                            //    .Referee
                            //    .Any(r =>
                            //        r.Firstname == game.Referee.Firstname &&
                            //        r.Lastname == game.Referee.Lastname);

                            //if (!refereeExists)
                            //{
                            //    _context.Add(game.Referee);
                            //}

                            ////todo: add side Refereees 
                            //var gameExists = _context.Game.Any(g =>
                            //    g.Date == game.Date &&
                            //    g.Place == game.Place);


                            //if (!gameExists)
                            //{
                            _context.Add(gameRecord);
                            //_context.Add(game.Spele); //?
                            //}
                            //}

                            await _context.SaveChangesAsync();

                        }
                    }
                }
            }
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using footballstats.Models;
using footballstats.Data;

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
                        List<Referee> referees;
                        fileContent = fileStream.ReadToEnd();
                        referees = JsonConvert.DeserializeObject<List<Referee>>(fileContent);

                        if (ModelState.IsValid)
                        {
                            foreach (var referee in referees)
                            {
                                var refereeExists = _context
                                    .Referee
                                    .Any(r =>
                                        r.Firstname == referee.Firstname &&
                                        r.Lastname == referee.Lastname);
                                if (!refereeExists)
                                {
                                    _context.Add(referee);
                                    await _context.SaveChangesAsync();
                                }
                        }
                        }
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}
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

namespace footballstats.Controllers
{
    public class UploadController : Controller
    {
        private IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
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
                        fileContent = fileStream.ReadToEnd();
                        var referees = JsonConvert.DeserializeObject<List<Referee>>(fileContent);
                    }
                }
            }
            return View();
        }
    }
}
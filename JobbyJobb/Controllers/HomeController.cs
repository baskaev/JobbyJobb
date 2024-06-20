using JobbyJobb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobbyJobb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContex datab;

        public HomeController(ILogger<HomeController> logger, DatabaseContex datab)
        {
            _logger = logger;
            this.datab = datab;
        }

        public IActionResult Index()
        {
            //Vacancy v = new Vacancy { Id = Guid.NewGuid(), Name = "name", Description = "232323", Comments = new List<Comment>() };
            //Comment c = new Comment { Id = Guid.NewGuid(), Text="dusdgd", Vacancy = v };
            //datab.Comments.Add(c);
            //v.Comments.Add(c);
            //datab.Vacancies.Add(v);
            //datab.SaveChanges();
            //Console.WriteLine(v.Name);

            var vacs = datab.Vacancies.AsQueryable();
            var result = vacs.ToList();

            return View(result);
        }

        public IActionResult AboutUS()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

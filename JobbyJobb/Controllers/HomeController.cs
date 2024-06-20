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

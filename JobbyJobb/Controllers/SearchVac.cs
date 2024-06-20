using JobbyJobb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JobbyJobb.Controllers
{
    public class SearchVac : Controller
    {
        private readonly ILogger<SearchVac> _logger;
        private readonly DatabaseContex datab;

        public SearchVac(ILogger<SearchVac> logger, DatabaseContex datab)
        {
            _logger = logger;
            this.datab = datab;
        }
        //public ActionResult Index(
        //    string searchstr,
        //    string name,
        //    string description,
        //    int salary,
        //    string educationLevel,
        //    float experience,
        //    string sector,
        //    string address,
        //    string schedule,
        //    string specialization
        //    )
        //{
        //    var vacs = datab.Vacancies.ToList();

        //    var result = new List<Vacancy>();

        //    foreach (var vacancy in vacs)
        //    {
        //        if (searchstr.Contains(vacancy.Name))
        //        {
        //            result.Add(vacancy);
        //        }
        //    }
        //    return View(result);
        //}

        public ActionResult Index(
            string searchstr,
            string name,
            string description,
            int? salary,
            string educationLevel,
            float? experience,
            string sector,
            string address,
            string schedule,
            string specialization,
            string status
        )
        {
            var vacs = datab.Vacancies.AsQueryable();

            if (!string.IsNullOrEmpty(searchstr))
            {
                vacs = vacs.Where(v => v.Name.Contains(searchstr) || v.Description.Contains(searchstr));
            }
            if (!string.IsNullOrEmpty(name))
            {
                vacs = vacs.Where(v => v.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(description))
            {
                vacs = vacs.Where(v => v.Description.Contains(description));
            }
            if (salary.HasValue)
            {
                vacs = vacs.Where(v => v.Salary >= salary.Value);
            }
            if (!string.IsNullOrEmpty(educationLevel))
            {
                vacs = vacs.Where(v => v.EducationLevel.Contains(educationLevel));
            }
            if (experience.HasValue)
            {
                vacs = vacs.Where(v => v.Experience >= experience.Value);
            }
            if (!string.IsNullOrEmpty(sector))
            {
                vacs = vacs.Where(v => v.Sector.Contains(sector));
            }
            if (!string.IsNullOrEmpty(address))
            {
                vacs = vacs.Where(v => v.Address.Contains(address));
            }
            if (!string.IsNullOrEmpty(schedule))
            {
                vacs = vacs.Where(v => v.Schedule.Contains(schedule));
            }
            if (!string.IsNullOrEmpty(specialization))
            {
                vacs = vacs.Where(v => v.Specialization.Contains(specialization));
            }
            if (!string.IsNullOrEmpty(status))
            {
                vacs = vacs.Where(v => v.Status.Contains(status));
            }

            var result = vacs.ToList();

            return View(result);
        }

        public ActionResult Details(Guid id)
        {
            Vacancy vacancy = datab.Vacancies
                                  .Include(v => v.Comments) // Включаем связанные комментарии
                                  .FirstOrDefault(v => v.Id == id);

            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        //public ActionResult Details(Guid id)
        //{
        //    Vacancy vacancy = datab.Vacancies
        //                          .FirstOrDefault(v => v.Id == id);

        //    if (vacancy == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vacancy);
        //}
    }
}

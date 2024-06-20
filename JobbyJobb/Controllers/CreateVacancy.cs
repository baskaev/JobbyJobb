using JobbyJobb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;

namespace JobbyJobb.Controllers
{
    public class CreateVacancy : Controller
    {
        private readonly ILogger<CreateVacancy> _logger;
        private readonly DatabaseContex datab;

        public CreateVacancy(ILogger<CreateVacancy> logger, DatabaseContex datab)
        {
            _logger = logger;
            this.datab = datab;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateVac(
            string name, 
            string description, 
            int salary, 
            string educationLevel, 
            float experience, 
            string sector, 
            string address, 
            string schedule, 
            string specialization,
            string status
            /*string employer*/)
{
            Vacancy v = new Vacancy { 
                Id = Guid.NewGuid(),  
                Name = name, 
                Description = description,
                Specialization = specialization,
                Schedule = schedule,
                Address = address,
                Sector = sector,
                Experience = experience,
                EducationLevel = educationLevel,
                Salary = salary,
                Comments = new List<Comment>(),
                Status = status
            };

            //Comment c = new Comment { 
            //    Id = Guid.NewGuid(), 
            //    Text = "dusdgd", 
            //    Vacancy = v 
            //};

            //v.Comments.Add(c);
            //datab.Comments.Add(c);
            //var arr = datab.Vacancies.Include(vac => vac.Comments).ToArray();
            //foreach (var a in arr)
            //{
            //    if (a.Comments != null)
            //    {
            //        foreach (var com in a.Comments)
            //        {
            //            Console.WriteLine(com.Text); // ПОЧЕМУ В КОНСОЛИ ПУСТО ХОТЯ В V.COMMENTS ЕСТЬ КОММЕНТАРИЙ?
            //        }
            //    }
            //}
            //Console.WriteLine();


            datab.Vacancies.Add(v);
            datab.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddComment(Guid VacancyId, string CommentText)
        {
            var userId = Request.Cookies["UserId"];
            var userRole = Request.Cookies["UserRole"];
            bool isAuthenticated = !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userRole);

            var vacancy = datab.Vacancies.FirstOrDefault(v => v.Id == VacancyId);

            if (Guid.TryParse(userId, out Guid parsedUserId))
            {
                if (userRole == "Employee")
                {
                    var user = datab.Employees.Where(u => u.Id == parsedUserId).FirstOrDefault();
                    if (vacancy != null)
                    {
                        var comment = new Comment
                        {
                            AnonName = datab.Employees.FirstOrDefault(u => u.Id == parsedUserId).Name,
                            Id = Guid.NewGuid(),
                            Text = CommentText,
                            Vacancy = vacancy
                        };
                        datab.Comments.Add(comment);
                        datab.SaveChanges();
                    }
                }
                if (userRole == "Employer")
                {
                    var user = datab.Employers.Where(u => u.Id == parsedUserId).FirstOrDefault();
                    if (vacancy != null)
                    {
                        var comment = new Comment
                        {
                            AnonName = datab.Employers.FirstOrDefault(u => u.Id == parsedUserId).Name,
                            Id = Guid.NewGuid(),
                            Text = CommentText,
                            Vacancy = vacancy
                        };
                        datab.Comments.Add(comment);
                        datab.SaveChanges();
                    }
                }
                if (userRole == "Admin" || userRole == "Moderator")
                {
                    var user = datab.Staff.Where(u => u.Id == parsedUserId).FirstOrDefault();
                    if (vacancy != null)
                    {
                        var comment = new Comment
                        {
                            AnonName = datab.Employees.FirstOrDefault(u => u.Id == parsedUserId).Name,
                            Id = Guid.NewGuid(),
                            Text = CommentText,
                            Vacancy = vacancy
                        };
                        datab.Comments.Add(comment);
                        datab.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Details", "SearchVac", new { id = VacancyId });
        }


        public IActionResult Respond(Guid VacancyId)
        {
            var userId = Request.Cookies["UserId"];
            var userRole = Request.Cookies["UserRole"];
            bool isAuthenticated = !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userRole);

            var vacancy = datab.Vacancies.FirstOrDefault(v => v.Id == VacancyId);
            datab.SaveChanges();
            
            return RedirectToAction("Details", "SearchVac", new { id = VacancyId });
        }
    }
}

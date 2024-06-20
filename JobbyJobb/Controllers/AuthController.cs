using JobbyJobb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobbyJobb.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly DatabaseContex datab;

        public AuthController(ILogger<AuthController> logger, DatabaseContex datab)
        {
            _logger = logger;
            this.datab = datab;
        }
        public IActionResult Form()
        {
            return View();
        }



        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(string Login, string Pass, string Role)
        {
            // админа или модератора можно создать только вручную
            Guid userId = Guid.NewGuid();
            if (Role == "Employee")
            {
                Employee n = new Employee()
                {
                    Id = userId,
                    Name = "null",
                    Role = Role,
                    HashPassword = Pass,
                    Login = Login,
                    Friends = new List<User>(),
                    Resumes = new List<Resume>()
                };
                datab.Employees.Add(n);
                datab.SaveChanges();
            }
            if (Role == "Employer")
            {
                Employer n = new Employer()
                {
                    Id = userId,
                    Name = "null",
                    Role = Role,
                    HashPassword = Pass,
                    Login = Login,
                    Friends = new List<User>(),
                    Vacancies = new List<Vacancy>()
                };
                datab.Employers.Add(n);
                datab.SaveChanges();
            }

            // Создание кук
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1)
            };

            Response.Cookies.Append("UserId", userId.ToString(), options);
            Response.Cookies.Append("UserRole", Role, options);

            return RedirectToAction("Index", "Home");
        }


        // POST: Auth/Login
        [HttpPost]
        public ActionResult Login(string Login, string Pass)
        {
            // Ищем пользователя с данным логином и паролем в таблице Employees
            var employee = datab.Employees.FirstOrDefault(e => e.Login == Login && e.HashPassword == Pass);

            if (employee != null)
            {
                // Пользователь найден как сотрудник
                SetCookies(employee.Id.ToString(), "Employee");
                return RedirectToAction("Index", "Home");
            }

            // Ищем пользователя с данным логином и паролем в таблице Employers
            var employer = datab.Employers.FirstOrDefault(e => e.Login == Login && e.HashPassword == Pass);

            if (employer != null)
            {
                // Пользователь найден как работодатель
                SetCookies(employer.Id.ToString(), "Employer");
                return RedirectToAction("Index", "Home");
            }

            var staff = datab.Staff.FirstOrDefault(e => e.Login == Login && e.HashPassword == Pass);

            if (employee != null)
            {
                // Пользователь найден как сотрудник
                SetCookies(employee.Id.ToString(), "Employee");
                return RedirectToAction("Index", "Home");
            }

            // Если пользователь не найден ни в одной из таблиц, редирект на страницу входа с ошибкой
            return RedirectToAction("Login", "Auth", new { error = true });
        }

        // Метод для установки кук
        private void SetCookies(string userId, string role)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1)
            };

            Response.Cookies.Append("UserId", userId, options);
            Response.Cookies.Append("UserRole", role, options);
        }

        
    }
}

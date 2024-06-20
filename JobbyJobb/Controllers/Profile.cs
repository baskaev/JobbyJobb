using JobbyJobb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobbyJobb.Controllers
{
    public class Profile : Controller

    {

        private readonly ILogger<Profile> _logger;
        private readonly DatabaseContex datab;

        public Profile(ILogger<Profile> logger, DatabaseContex datab)
        {
            _logger = logger;
            this.datab = datab;
        }
        // GET: Profile
        public ActionResult User()
        {
            var userId = Request.Cookies["UserId"];
            var userRole = Request.Cookies["UserRole"];
            bool isAuthenticated = !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(userRole);
            if (isAuthenticated)
            {
                if (Guid.TryParse(userId, out Guid parsedUserId))
                {
                    if (userRole == "Employee")
                    {
                        var user = datab.Employees.Where(u => u.Id == parsedUserId).FirstOrDefault();
                        return View(user);
                    }
                    if (userRole == "Employer")
                    {
                        var user = datab.Employers.Where(u => u.Id == parsedUserId).FirstOrDefault();
                        return View(user);
                    }
                    if (userRole == "Admin" || userRole == "Moderator")
                    {
                        var user = datab.Staff.Where(u => u.Id == parsedUserId).FirstOrDefault();
                        return View(user);
                    }
                }
                else
                {
                    // Неверный формат userId
                    return RedirectToAction("Form", "Auth");
                }
            }

            return RedirectToAction("Form", "Auth");
        }

        public ActionResult Change(string Name, string PhoneNumber, string Email)
        {
            var userId = Request.Cookies["UserId"];
            var userRole = Request.Cookies["UserRole"];

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userRole))
            {
                // Если нет куки, перенаправляем на страницу входа
                return RedirectToAction("Form", "Auth");
            }

            // Парсим userId (если он в виде строки, нужно преобразовать в нужный формат, например Guid)
            Guid parsedUserId;
            if (!Guid.TryParse(userId, out parsedUserId))
            {
                // Неверный формат userId, перенаправляем на страницу входа
                return RedirectToAction("Form", "Auth");
            }

            if (userRole == "Employee")
            {
                var user = datab.Employees.FirstOrDefault(u => u.Id == parsedUserId);
                if (user != null)
                {
                    user.Name = Name;
                    user.PhoneNumber = PhoneNumber;
                    user.Email = Email;
                }
            }
            else if (userRole == "Employer")
            {
                var user = datab.Employers.FirstOrDefault(u => u.Id == parsedUserId);
                if (user != null)
                {
                    user.Name = Name;
                    user.PhoneNumber = PhoneNumber;
                    user.Email = Email;
                }
            }
            else if (userRole == "Admin" || userRole == "Moderator")
            {
                var user = datab.Staff.FirstOrDefault(u => u.Id == parsedUserId);
                if (user != null)
                {
                    user.Name = Name;
                    user.PhoneNumber = PhoneNumber;
                    user.Email = Email;
                }
            }
            else
            {
                // Если роль не распознана, перенаправляем на страницу входа
                return RedirectToAction("Form", "Auth");
            }

            // Сохраняем изменения в базе данных
            datab.SaveChanges();

            // Перенаправляем пользователя на его профиль
            return RedirectToAction("User");
        }


        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        
    }
}

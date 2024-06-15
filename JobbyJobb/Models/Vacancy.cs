using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace JobbyJobb.Models
{
    public class Vacancy
    {
        public Guid Id { get; set; }

        //public string PhotoPath { get; set; } // фото нанимателя можно брать через Employer
        public Employer? Employer { get; set; } // тот кто нанимает
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Specialization { get; set; } // специализация
        public string? Schedule { get; set; } // график работы
        public string? Address { get; set; } = "null";
        public List<User>? Responded { get; set; } // ответили 
        public string? Sector { get; set; } // отрасль
        public float? Experience { get; set; } // минимальныый опыт
        public string? EducationLevel { get; set; } = "null"; // уровень образования
        public int? Salary { get; set; } // зарплата в месяц
        public List<Comment>? Comments { get; set; } // комментрарии

        public string? Status { get; set; } // статус вакансии
    }
}

namespace JobbyJobb.Models
{
    public class Resume
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; } = new Employee();  // тот кто ищет работу
        public string Name { get; set; } = "null";
        public string Description { get; set; } = "null";
        public string Specialization { get; set; } = "null"; // специализация
        public string Schedule { get; set; } = "null"; // желаемый график работы
        public string EmploymentType { get; set; } = "null"; // желаемый тип занетости
        public string Address { get; set; } = "null"; // адрес проживания
        public List<User> Responded { get; set; } // ответили на вакансию 
        public string Sector { get; set; } // отрасль 
        public float Experience { get; set; } // опыт работы
        public List<string> Skills { get; set; } // ключевые навыки
        public string EducationLevel { get; set; } // уровень образования
        public int Salary { get; set; } // желаемая зарплата в месяц
        public int Status { get; set; } // статус поиска
        public int Сitizenship { get; set; } // статус поиска
    }
}

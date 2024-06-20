namespace JobbyJobb.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? PhotoPath { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }
        public string Name { get; set; } // имя человека
        public string Role { get; set; } // admin employer employee moderator
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<User> Friends { get; set; }
    }
    public class Employer : User
    {
        public List<Vacancy> Vacancies { get; set; }
    }
    public class Employee : User
    {
        public List<Resume> Resumes { get; set; }
    }
}

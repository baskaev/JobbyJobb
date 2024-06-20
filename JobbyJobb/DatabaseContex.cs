using JobbyJobb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobbyJobb
{
    public class DatabaseContex : DbContext
    {
        // так как рабочий и наниматель наследуются от юзера в базе данных они хранятся в таблице стафф
        public DbSet<User> Staff { get; set; } // тут будут Админы и модераторы
        public DbSet<Employee> Employees { get; set; } // для юзеров рабочих
        public DbSet<Employer> Employers { get; set; } // для юзеров нанимателей
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

        public DatabaseContex(DbContextOptions<DatabaseContex> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

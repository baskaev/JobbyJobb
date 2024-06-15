using JobbyJobb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobbyJobb
{
    public class DatabaseContex : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

        public DatabaseContex(DbContextOptions<DatabaseContex> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StudentGradingAPI.Models;

namespace StudentGradingAPI.Data
{
    public class StudentAPIDbContext : DbContext
    {
        public StudentAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}

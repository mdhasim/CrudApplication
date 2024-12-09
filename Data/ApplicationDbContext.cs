using CrudApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Login> Users { get; set; }
    }
}

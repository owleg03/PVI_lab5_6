using Microsoft.EntityFrameworkCore;
using Lab6.Models;

namespace Lab6.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Account>? Account { get; set; }
    }
}

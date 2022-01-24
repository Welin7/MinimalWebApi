using Microsoft.EntityFrameworkCore;
using MinimalWebApi.Models;

namespace MinimalWebApi.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) => Database.EnsureCreated();

        public DbSet<Doctor> Doctor { get; set; }
        
    }
}

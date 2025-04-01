using CognitusBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CognitusBackend.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) 
        { 

        }

    }
}

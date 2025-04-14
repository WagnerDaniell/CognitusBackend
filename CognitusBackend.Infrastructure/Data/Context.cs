using CognitusBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CognitusBackend.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserSearch> UserSearches { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserSearch>()
                .HasOne(r => r.User)
                .WithMany(t => t.UserSearches)
                .HasForeignKey(r => r.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}

using Microsoft.EntityFrameworkCore;
using ums_dotnet.Entities;

namespace ums_dotnet.DbContexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Authority> Authority { get; set; } = null!;

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User(1, "Johnny", "Depp", "John1", "johnny123", "johnny@depp.com", "Active"),
                    new User(2, "Jimm", "Carrey", "Jimm1", "Jimm123", "jimm@carrey.com", "Active"),
                    new User(3, "Angelina", "Jolie", "Angelina1", "angelina123", "angelina@jolie.com", "Active")
                    );
            base.OnModelCreating(modelBuilder); 
        }
    }
}

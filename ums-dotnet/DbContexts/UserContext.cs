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
                    new User(3, "Angelina", "Jolie", "Angelina1", "angelina123", "angelina@jolie.com", "Active"),
                    new User(4, "Dwayne", "Johnson", "Dwayne1", "dwayne123", "dwayne@johnson.com", "Active"),
                    new User(5, "Tom", "Hanks", "Tom1", "tom123", "tom@hanks.com", "Active"),
                    new User(6, "Tom", "Cruise", "Tom1", "tom123", "tom@cruise.com", "Active"),
                    new User(7, "Monica", "Belucci", "Monica1", "belucci123", "monica@belucci.com", "Inactive"),
                    new User(8, "Anthony", "Hopkins", "Anthony1", "anthony123", "anthony@hopkins.com", "Inactive"),
                    new User(9, "Jack", "Nicholson", "Jack1", "jack123", "jack@nicholson.com", "Inactive"),
                    new User(10, "Al", "Pacino", "Al1", "al123", "al@pacino.com", "Active"),
                    new User(11, "Dustin", "Hoffman", "Dustin1", "dustin123", "dustin@hoffman.com", "Active"),
                    new User(12, "Denzel", "Washington", "Danzel1", "danzel123", "danzel@washington.com", "Active"),
                    new User(13, "Robin", "Williams", "Robin1", "robin123", "robin@williams.com", "Active"),
                    new User(14, "Morgan", "Freeman", "Morgan1", "morgan123", "morgan@freeman.com", "Active"),
                    new User(15, "Gene", "Hackman", "Gene1", "gene123", "gene@hackman.com", "Inactive")
                    );
            base.OnModelCreating(modelBuilder); 
        }
    }
}

using Guessing_Game.Models;
using Microsoft.EntityFrameworkCore;

namespace Guessing_Game.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //added to disable auto-increment function on ID
            modelBuilder.Entity<Person>()
            .Property(c => c.PersonId)
            .ValueGeneratedNever();

            //Person data seeding till Context
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Joe", City = "Liverpool", PhoneNumber = "700-309-341", PersonId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Josef", City = "Stockholm", PhoneNumber = "763-385-323", PersonId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Gilbert", City = "Warszawa", PhoneNumber = "774-375-333", PersonId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Brad", City = "Barcelona", PhoneNumber = "775-346-312", PersonId = 4 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Luka", City = "Los Angeles", PhoneNumber = "775-314-347", PersonId = 5 });



        }
    }

    
}

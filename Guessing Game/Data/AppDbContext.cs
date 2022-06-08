using Guessing_Game.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Guessing_Game.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //added to disable auto-increment function on Person ID
            //modelBuilder.Entity<Person>()
            //.Property(c => c.PersonId)
            //.ValueGeneratedNever();

            modelBuilder.Entity<PersonLanguage>().HasKey(co => new { co.PersonId, co.LanguageId });

            //City data seeding till Context
            modelBuilder.Entity<City>().HasData(new City { CityName = "Stockholm", CityId = 1, CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Barcelona", CityId = 2, CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Madrid", CityId = 3, CountryId = 3 });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Oslo", CityId = 4, CountryId = 4 });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Helsinki", CityId = 5, CountryId = 2 });

            //Country data seeding till Context
            modelBuilder.Entity<Country>().HasData(new Country { CountryName ="Sweden", CountryId = 1 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Finland", CountryId = 2 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Spain", CountryId = 3 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Norway", CountryId = 4 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Poland", CountryId = 5 });

            //Person data seeding till Context
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Joe", PhoneNumber = "700-309-341", PersonId = 1, CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Josef", PhoneNumber = "763-385-323", PersonId = 2, CityId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Gilbert", PhoneNumber = "774-375-333", PersonId = 3, CityId = 4 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Brad", PhoneNumber = "775-346-312", PersonId = 4, CityId = 5 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Luka", PhoneNumber = "775-314-347", PersonId = 5, CityId = 3 });

            //Language data seeding till Context
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Spanish", LanguageId = 1 });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Swedish", LanguageId = 2 });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "English", LanguageId = 3 });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Chinese", LanguageId = 4 });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Polish", LanguageId = 5 });

            //Language data seeding till Context
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 1, PersonId = 4});
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 2, PersonId = 2});
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 3, PersonId = 5});
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 4, PersonId = 1});
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 5, PersonId = 3});




            //City -> List of People relation - 1 to many
            modelBuilder.Entity<City>()
                .HasMany(co => co.People)
                .WithOne(c => c.City);
                

            //Country -> List of Cities relation - 1 to many
            modelBuilder.Entity<Country>()
                .HasMany(co => co.Cities)
                .WithOne(c => c.Country);

            

            // 2 x one to many = many to many
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(co => co.Language)
                .WithMany(c => c.PersonLanguages)
                .HasForeignKey(c => c.LanguageId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(co => co.Person)
                .WithMany(c => c.PersonLanguages)
                .HasForeignKey(c => c.PersonId);



        }
    }

    
}

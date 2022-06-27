using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NawOpdracht.Data.DataObjects;

namespace NawOpdracht.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            //Added Method to ensure the tabels are created.(without this you will get an SqlExceptopn error)
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(new List<Address>
            {
                new Address
                {
                    Id = 1,
                    HouseNumber = "12a",
                    StreetName = "SomeStreet",
                    Town = "Amsterdam"
                },
                new Address                {
                    Id = 2,
                    HouseNumber = "23",
                    StreetName = "SomeStreet2",
                    Town = "DenHaag"
                },
            });

            modelBuilder.Entity<Person>().HasData(new List<Person>
            {
                new Person
                {
                    Id = 1,
                    AddressId = 2,
                    Age = 39,
                    FirstName = "Henk",
                    LastName = "Van den Tillaard",
                    Gender = "male"
                },
                new Person
                {
                    Id = 2,
                    AddressId = 1,
                    Age = 68,
                    FirstName = "Truus",
                    LastName = "Huus",
                    Gender = "female"
                }
            });
        }
    }
}

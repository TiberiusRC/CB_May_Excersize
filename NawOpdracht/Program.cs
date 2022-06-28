using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NawOpdracht.Data;
using NawOpdracht.Data.DataObjects;
using NawOpdracht.services;
using Newtonsoft.Json;


namespace NawOpdracht
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainDbContext beeWelcomeDbContext = CreateDbContext();

            var personService = new PersonService(beeWelcomeDbContext);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            // Person
            int age;
            string firstName;
            string lastName;
            string gender;

            // Address
            string streetName;
            string town;
            string houseNumber;
                  

            // Todo gather Address information
            bool result = false;
            do
            {   Console.WriteLine("Enter your first name: ");
                firstName = Console.ReadLine();
                bool stringCheck = firstName.All(Char.IsLetter);
                if (stringCheck == true)
                {                    
                    result = false;                   
                }
                else
                {
                    Console.WriteLine("Incorrect input , enter letters only");
                    result = true;
                }
                
            } while (result);  

            Console.WriteLine("Enter your last name: ");
            lastName = Console.ReadLine();

            Console.WriteLine("Enter your gender: ");
            gender = Console.ReadLine();

            Console.WriteLine("Enter your age: ");

            // Todo check the input data
            // Converted string to int
            age = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Enter your streetname: ");
            streetName = Console.ReadLine();

            Console.WriteLine("Enter your town: ");
            town = Console.ReadLine();

            Console.WriteLine("Enter your houseNumber: ");
            houseNumber = Console.ReadLine();

            var newPerson = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender,
                Address = new Address
                {
                    StreetName = streetName,
                    HouseNumber = houseNumber,
                    Town = town
                }
            };

            Console.WriteLine("New Person:");
            Console.WriteLine(
                JsonConvert.SerializeObject(newPerson, Formatting.Indented));

            personService.AddPerson(newPerson);

            Console.WriteLine("All Persons:");
            var allPersons = personService.GetAllPersons();
            foreach (var person in allPersons)
            {
                Console.WriteLine(
                    JsonConvert.SerializeObject(person, Formatting.Indented));
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        public static MainDbContext CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetSection("DatabaseConnectionString").Value;

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MainDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            var provider = serviceCollection.BuildServiceProvider();
            return provider.GetService<MainDbContext>();
        }

        public class DesignTimeMainDbContext : IDesignTimeDbContextFactory<MainDbContext>
        {
            MainDbContext IDesignTimeDbContextFactory<MainDbContext>.CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<MainDbContext>();
                var connectionString = configuration.GetSection("DatabaseConnectionString").Value;

                builder.UseSqlServer(connectionString);

                return new MainDbContext(builder.Options);
            }
        }
    }
}

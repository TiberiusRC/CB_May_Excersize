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
    internal class CollectInfo
    {               

        public static void InfoConsole()
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

            // Do while loop to repeat the step if no string is submitted.
            // StringCheck method to check if input is a valid string.
            bool resultCheck = false;
            do
            {
                Console.WriteLine("Enter your first name: ");
                firstName = Console.ReadLine();
                StringCheck(firstName, out resultCheck);

            } while (resultCheck);

            // Do while loop to repeat the step if no string is submitted.
            // StringCheck method to check if input is a valid string.
            do
            {
                Console.WriteLine("Enter your last name: ");
                lastName = Console.ReadLine();
                StringCheck(lastName, out resultCheck);

            } while (resultCheck);

            // Do while loop to repeat the step if no correct answer is submitted.
            do
            {
                Console.WriteLine("Enter your gender:(Male or Female) ");
                gender = Console.ReadLine();

                if (gender.ToLower() == "male")
                {
                    resultCheck = false;
                }
                else if (gender.ToLower() == "female")
                {
                    resultCheck = false;
                }
                else
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("- Incorrect input , enter ' Male ' or ' Female ' only -");
                    Console.WriteLine("-------------------------------------------------------");
                    resultCheck = true;
                }

            } while (resultCheck);            

            // Todo check the input data
            // Converted string to int
            
            // Do while loop to repeat the step if no number is submitted.
            do
            {                
                Console.WriteLine("Enter your age: ");
                String response = Console.ReadLine();
                if (int.TryParse(response, out age))
                {
                    resultCheck = false;
                }
                else
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("-You didn't enter a proper number!-");
                    Console.WriteLine("-----------------------------------");
                    resultCheck =true;
                }
            } while (resultCheck);         

            // Do while loop to repeat the step if no string is submitted.
            // StringCheck method to check if input is a valid string.
            do
            {
                Console.WriteLine("Enter your streetName: ");
                streetName = Console.ReadLine();
                StringCheck(streetName, out resultCheck);

            } while (resultCheck);

            // Do while loop to repeat the step if no string is submitted.
            // StringCheck method to check if input is a valid string.
            do
            {
                Console.WriteLine("Enter your town: ");
                town = Console.ReadLine();
                StringCheck(town, out resultCheck);

            } while (resultCheck);

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
        public static bool StringCheck(string input, out bool resultCheck)
        {
            bool stringCheck = input.All(Char.IsLetter);
            //bool resultCheck;
            if (stringCheck == true)
            {
                resultCheck = false;
                return resultCheck;

            }
            else
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("- Incorrect input , enter letters only -");
                Console.WriteLine("----------------------------------------");
                resultCheck = true;
                return resultCheck;

            }
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

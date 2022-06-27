using NawOpdracht.Data;
using NawOpdracht.Data.DataObjects;
using System.Collections.Generic;
using System.Linq;

namespace NawOpdracht.services
{
    public class PersonService
    {
        public MainDbContext MainDbContext { get; }

        public PersonService(MainDbContext mainDbContext)
        {
            MainDbContext = mainDbContext;
        }

        public List<Person> GetAllPersons()
        {
            var allPersons = MainDbContext.Persons.ToList();
            if (allPersons.Any())
            {
                return allPersons;
            }
            return new List<Person>();

        }

        public void AddPerson(Person person)
        {
            MainDbContext.Persons.Add(person);
            MainDbContext.SaveChanges();
        }
    }
}

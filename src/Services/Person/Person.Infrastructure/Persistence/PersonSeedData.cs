using Microsoft.Extensions.Logging;
using Person.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Infrastructure.Persistence
{
    public class PersonSeedData
    {
        public static async Task SeedAsync(PersonContext personContext, ILogger<PersonSeedData> logger)
        {
            if (!personContext.People.Any())
            {
                personContext.People.AddRange(SeedPersonData());
                await personContext.SaveChangesAsync();
                logger.LogInformation("Seed database with default Person data.");
            }
            if (!personContext.PeopleAddresses.Any())
            {
                personContext.PeopleAddresses.AddRange(SeedPersonAddressData());
                await personContext.SaveChangesAsync();
                logger.LogInformation("Seed database with default Person address data.");
            }
        }

        private static IEnumerable<Person_Address> SeedPersonAddressData()
        {
            return new List<Person_Address>
            {
                new Person_Address
                {
                    Person_Id = 1,
                    Type = "Home",
                    Street = "123 Main Street",
                    City = "Seattle",
                    State = "WA",
                    ZipCode = 17803
                },
                new Person_Address
                {
                    Person_Id = 1,
                    Type = "Work",
                    Street = "543 Westminster Ave",
                    City = "Seattle",
                    State = "WA",
                    ZipCode = 17854
                },
                new Person_Address
                {
                    Person_Id = 2,
                    Type = "Home",
                    Street = "5686 Mailer Rd",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 51584
                },
                new Person_Address
                {
                    Person_Id = 2,
                    Type = "Work",
                    Street = "38366 Filler Ave",
                    City = "Dallas",
                    State = "TX",
                    ZipCode = 54486
                }
            };
        }

        private static IEnumerable<Domain.Entities.Person> SeedPersonData()
        {
            return new List<Domain.Entities.Person>
            {
                new Domain.Entities.Person()
                {
                    FirstName = "M'Bemba",
                    MiddleInitial = "A",
                    LastName = "Kawah",
                    Title = "Mr",
                    Rank = "Colonel",
                    Gender = "Male",
                    Weight = 195,
                    Height = 72,
                    EyeColor = "Blue",
                    Race = "Black or African American",
                    IsActive = true
                },
                new Domain.Entities.Person()
                {
                    FirstName = "Tony",
                    MiddleInitial = "N",
                    LastName = "Piccirilli",
                    Title = "Mr",
                    Rank = "Colonel",
                    Gender = "Male",
                    Weight = 195,
                    Height = 72,
                    EyeColor = "Blue",
                    Race = "Caucasian",
                    IsActive = true
                }
            };
        }
    }
}

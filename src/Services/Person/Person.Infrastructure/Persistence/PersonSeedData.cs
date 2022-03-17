using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure.Persistence
{
    public class PersonSeedData
    {
        public static async Task SeedAsync(PersonContext personContext, ILogger<PersonSeedData> logger)
        {
            if (!personContext.People.Any())
            {
                personContext.People.AddRange(SeedData());
                await personContext.SaveChangesAsync();
                logger.LogInformation("Seed database with default Person data.");
            }
        }

        private static IEnumerable<Domain.Entities.Person> SeedData()
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

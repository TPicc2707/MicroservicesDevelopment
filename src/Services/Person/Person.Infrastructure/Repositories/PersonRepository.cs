using Microsoft.EntityFrameworkCore;
using Person.Application.Contracts.Persistence;
using Person.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repositories
{
    public class PersonRepository : RepositoryBase<Domain.Entities.Person>, IPersonRepository
    {
        public PersonRepository(PersonContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetActivePeople(bool isActive)
        {
            var personList = await _dbContext.People.Where(p => p.IsActive == isActive).ToListAsync();

            return personList;
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetPeopleByLastName(string lastName)
        {
            var personList = await _dbContext.People.Where(p => p.LastName == lastName).OrderBy(p => p.LastName).ToListAsync();

            return personList;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Person.Application.Contracts.Persistence;
using Person.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repositories
{
    public class PersonRepository : RepositoryBase<Domain.Entities.Person>, IPersonRepository
    {
        public PersonRepository(PersonContext dbContext) : base(dbContext)
        {

        }

        public async Task<Domain.Entities.Person> GetPersonById(int Id)
        {
            var person = await _dbContext.People.Where(p => p.ID == Id).Include(p => p.Addresses).FirstOrDefaultAsync();

            return person;
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetActivePeople(bool isActive)
        {
            var personList = await _dbContext.People.Where(p => p.IsActive == isActive).Include(p => p.Addresses).ToListAsync();

            return personList;
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetPeopleByLastName(string lastName)
        {
            var personList = await _dbContext.People.Where(p => p.LastName == lastName).Include(p => p.Addresses).OrderBy(p => p.LastName).ToListAsync();

            return personList;
        }
    }
}

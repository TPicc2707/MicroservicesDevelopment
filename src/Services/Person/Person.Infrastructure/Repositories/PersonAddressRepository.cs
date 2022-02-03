using Microsoft.EntityFrameworkCore;
using Person.Application.Contracts.Persistence;
using Person.Domain.Entities;
using Person.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repositories
{
    public class PersonAddressRepository : RepositoryBase<Person_Address>, IPersonAddressRepository
    {
        public PersonAddressRepository(PersonContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Person_Address>> GetAddressesByType(string type)
        {
            var addressList = await _dbContext.PeopleAddresses.Where(a => a.Type == type).OrderBy(a => a.State).ToListAsync();

            return addressList;
        }
    }
}

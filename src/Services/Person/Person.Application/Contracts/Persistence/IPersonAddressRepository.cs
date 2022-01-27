using Person.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Contracts.Persistence
{
    public interface IPersonAddressRepository : IAsyncRepository<Person_Address>
    {
    }
}

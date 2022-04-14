using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IPersonRepository People { get; }
        IPersonAddressRepository Person_Addresses { get; }
    }
}

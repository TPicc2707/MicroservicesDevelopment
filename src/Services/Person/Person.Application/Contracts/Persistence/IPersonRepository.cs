﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Person.Application.Contracts.Persistence
{
    public interface IPersonRepository : IAsyncRepository<Domain.Entities.Person>
    {
        Task<IEnumerable<Domain.Entities.Person>> GetActivePeople(bool isActive);
    }
}

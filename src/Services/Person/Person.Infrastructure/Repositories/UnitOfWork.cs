using Person.Application.Contracts.Persistence;
using Person.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private PersonContext _context;

        public UnitOfWork(PersonContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            InitializeRepositories();
        }

        public IPersonRepository People { get; private set; }

        public IPersonAddressRepository Person_Addresses { get; private set; }

        private void InitializeRepositories()
        {
            People = new PersonRepository(_context);
            Person_Addresses = new PersonAddressRepository(_context);
        }
    }
}

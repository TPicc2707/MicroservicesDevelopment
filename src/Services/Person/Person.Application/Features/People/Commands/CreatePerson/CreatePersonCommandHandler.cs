using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommandVm, int>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonCommandHandler> _logger;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper,
             ILogger<CreatePersonCommandHandler> logger)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreatePersonCommandVm request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Domain.Entities.Person>(request);
            var newPerson = await _personRepository.AddAsync(person);

            _logger.LogInformation($"New Person {person.ID} was successfully created.");

            return newPerson.ID;

        }
    }
}

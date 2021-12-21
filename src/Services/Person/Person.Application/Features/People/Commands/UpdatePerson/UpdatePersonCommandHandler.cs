using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Contracts.Persistence;
using Person.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommandVm>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePersonCommandHandler> _logger;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper,
             ILogger<UpdatePersonCommandHandler> logger)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdatePersonCommandVm request, CancellationToken cancellationToken)
        {
            var personUpdate = await _personRepository.GetByIdAsync(request.ID);
            if(personUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Person), request.ID);
            }

            _mapper.Map(request, personUpdate, typeof(UpdatePersonCommandVm), typeof(Domain.Entities.Person));

            await _personRepository.UpdateAsync(personUpdate);

            _logger.LogInformation($"Person {personUpdate.ID} was successfully updated.");

            return Unit.Value;

        }
    }
}

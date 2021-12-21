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

namespace Person.Application.Features.People.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommandVm>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePersonCommandVm> _logger;

        public DeletePersonCommandHandler(IPersonRepository personRepository, IMapper mapper,
             ILogger<DeletePersonCommandVm> logger)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeletePersonCommandVm request, CancellationToken cancellationToken)
        {
            var personDelete = await _personRepository.GetByIdAsync(request.ID);
            if (personDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Person), request.ID);
            }

            await _personRepository.DeleteAsync(personDelete);

            _logger.LogInformation($"Person {personDelete.ID} was successfully deleted.");

            return Unit.Value;

        }

    }
}

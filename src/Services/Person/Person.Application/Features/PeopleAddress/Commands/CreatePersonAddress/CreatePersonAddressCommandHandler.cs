using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Contracts.Persistence;
using Person.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Commands.CreatePersonAddress
{
    public class CreatePersonAddressCommandHandler : IRequestHandler<CreatePersonAddressCommandVm, int>
    {
        private readonly IPersonAddressRepository _personAddressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonAddressCommandHandler> _logger;

        public CreatePersonAddressCommandHandler(IPersonAddressRepository personAddressRepository, IMapper mapper,
            ILogger<CreatePersonAddressCommandHandler> logger)
        {
            _personAddressRepository = personAddressRepository ?? throw new ArgumentNullException(nameof(personAddressRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreatePersonAddressCommandVm request, CancellationToken cancellationToken)
        {
            var personAddressEntity = _mapper.Map<Person_Address>(request);
            var newPersonAddress = await _personAddressRepository.AddAsync(personAddressEntity);

            _logger.LogInformation($"Address {newPersonAddress.ID} is successfully created.");

            return newPersonAddress.ID;
        }
    }
}

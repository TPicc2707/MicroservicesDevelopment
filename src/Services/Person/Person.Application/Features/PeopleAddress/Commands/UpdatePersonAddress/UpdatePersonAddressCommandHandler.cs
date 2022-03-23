using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Contracts.Persistence;
using Person.Application.Exceptions;
using Person.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Commands.UpdatePersonAddress
{
    public class UpdatePersonAddressCommandHandler : IRequestHandler<UpdatePersonAddressCommandVm>
    {
        private readonly IPersonAddressRepository _personAddressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePersonAddressCommandHandler> _logger;

        public UpdatePersonAddressCommandHandler(IPersonAddressRepository personAddressRepository, IMapper mapper,
            ILogger<UpdatePersonAddressCommandHandler> logger)
        {
            _personAddressRepository = personAddressRepository ?? throw new ArgumentNullException(nameof(personAddressRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdatePersonAddressCommandVm request, CancellationToken cancellationToken)
        {
            var personAddressUpdate = await _personAddressRepository.GetByIdAsync(request.ID);
            if (personAddressUpdate == null)
            {
                throw new NotFoundException(nameof(Person_Address), request.ID);
            }

            _mapper.Map(request, personAddressUpdate, typeof(UpdatePersonAddressCommandVm), typeof(Person_Address));

            await _personAddressRepository.UpdateAsync(personAddressUpdate);

            _logger.LogInformation($"Person address {personAddressUpdate.ID} was successfully updated.");

            return Unit.Value;
        }
    }
}

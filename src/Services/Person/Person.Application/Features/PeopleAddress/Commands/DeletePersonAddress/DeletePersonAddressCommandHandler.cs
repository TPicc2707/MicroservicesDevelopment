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

namespace Person.Application.Features.PeopleAddress.Commands.DeletePersonAddress
{
    public class DeletePersonAddressCommandHandler : IRequestHandler<DeletePersonAddressCommandVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePersonAddressCommandVm> _logger;

        public DeletePersonAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
             ILogger<DeletePersonAddressCommandVm> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeletePersonAddressCommandVm request, CancellationToken cancellationToken)
        {
            var personAddressDelete = await _unitOfWork.Person_Addresses.GetByIdAsync(request.ID);
            if (personAddressDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Person), request.ID);
            }

            await _unitOfWork.Person_Addresses.DeleteAsync(personAddressDelete);

            _logger.LogInformation($"Person address {personAddressDelete.ID} was successfully deleted.");

            return Unit.Value;

        }
    }
}

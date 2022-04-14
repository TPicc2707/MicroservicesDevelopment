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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePersonCommandHandler> _logger;

        public UpdatePersonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
             ILogger<UpdatePersonCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdatePersonCommandVm request, CancellationToken cancellationToken)
        {
            var personUpdate = await _unitOfWork.People.GetByIdAsync(request.ID);
            if(personUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Person), request.ID);
            }

            _mapper.Map(request, personUpdate, typeof(UpdatePersonCommandVm), typeof(Domain.Entities.Person));

            await _unitOfWork.People.UpdateAsync(personUpdate);

            _logger.LogInformation($"Person {personUpdate.ID} was successfully updated.");

            return Unit.Value;

        }
    }
}

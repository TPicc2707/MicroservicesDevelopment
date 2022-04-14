using AutoMapper;
using MediatR;
using Person.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Queries
{
    public class GetPersonAddressByIdQueryHandler : IRequestHandler<GetPersonAddressByIdQuery, PersonAddressVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonAddressByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PersonAddressVm> Handle(GetPersonAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _unitOfWork.Person_Addresses.GetByIdAsync(request.Id);

            return _mapper.Map<PersonAddressVm>(addresses);
        }
    }
}

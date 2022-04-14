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
    public class GetPersonAddressListQueryHandler : IRequestHandler<GetPersonAddressListQuery, List<PersonAddressVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonAddressListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PersonAddressVm>> Handle(GetPersonAddressListQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _unitOfWork.Person_Addresses.GetAddressesByType(request.Type);

            return _mapper.Map<List<PersonAddressVm>>(addresses);
        }
    }
}

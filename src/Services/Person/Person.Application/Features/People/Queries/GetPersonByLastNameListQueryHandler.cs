using AutoMapper;
using MediatR;
using Person.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Queries
{
    public class GetPersonByLastNameListQueryHandler : IRequestHandler<GetPersonByLastNameListQuery, List<PersonViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonByLastNameListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PersonViewModel>> Handle(GetPersonByLastNameListQuery request, CancellationToken cancellationToken)
        {
            var people = await _unitOfWork.People.GetPeopleByLastName(request.LastName);

            return _mapper.Map<List<PersonViewModel>>(people);
        }
    }
}

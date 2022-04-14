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
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, PersonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PersonViewModel> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.People.GetPersonById(request.Id);
            return _mapper.Map<PersonViewModel>(person);
        }
    }
}

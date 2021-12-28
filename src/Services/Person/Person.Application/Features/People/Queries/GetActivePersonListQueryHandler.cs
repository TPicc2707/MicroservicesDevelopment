using AutoMapper;
using MediatR;
using Person.Application.Contracts.Persistence;
using Person.Application.Features.People.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Queries
{
    public class GetActivePersonListQueryHandler : IRequestHandler<GetPersonListQuery, List<PersonViewModel>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetActivePersonListQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PersonViewModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var personIsActiveList = await _personRepository.GetActivePeople(request.IsActive);

            return _mapper.Map<List<PersonViewModel>>(personIsActiveList);
        }
    }
}

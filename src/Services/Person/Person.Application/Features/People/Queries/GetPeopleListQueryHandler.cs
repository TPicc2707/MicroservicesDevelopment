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
    public class GetPeopleListQueryHandler : IRequestHandler<GetPeopleListQuery,List<PersonViewModel>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPeopleListQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PersonViewModel>> Handle(GetPeopleListQuery request, CancellationToken cancellationToken)
        {
            var peopleList = await _personRepository.GetAllAsync();
            return _mapper.Map<List<PersonViewModel>>(peopleList);
        }
    }
}

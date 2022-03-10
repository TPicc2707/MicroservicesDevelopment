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
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PersonViewModel> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetPersonById(request.Id);
            return _mapper.Map<PersonViewModel>(person);
        }
    }
}

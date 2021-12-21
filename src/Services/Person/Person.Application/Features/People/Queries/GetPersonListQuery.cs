using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Queries
{
    public class GetPersonListQuery : IRequest<List<PersonViewModel>>
    {
        public bool IsActive { get; set; }

        public GetPersonListQuery(bool isActive)
        {
            IsActive = isActive;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Queries
{
    public class GetPersonByLastNameListQuery : IRequest<List<PersonViewModel>>
    {
        public string LastName { get; set; }

        public GetPersonByLastNameListQuery(string lastName)
        {
            LastName = lastName;
        }


    }
}

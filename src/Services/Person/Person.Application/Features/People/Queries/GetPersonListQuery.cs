using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Queries
{
    public class GetPersonListQuery : IRequest<PersonViewModel>
    {
        public int Id { get; set; }
        public GetPersonListQuery(int id)
        {
            Id = id;
        }
    }
}

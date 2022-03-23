using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Queries
{
    public class GetPersonAddressByIdQuery : IRequest<PersonAddressVm>
    {
        public int Id { get; set; }
        public GetPersonAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}

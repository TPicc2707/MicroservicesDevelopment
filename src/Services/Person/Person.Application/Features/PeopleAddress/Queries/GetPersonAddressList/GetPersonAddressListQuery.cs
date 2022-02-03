using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Queries.GetPersonAddressList
{
    public class GetPersonAddressListQuery : IRequest<List<PersonAddressVm>>
    {
        public string Type { get; set; }

        public GetPersonAddressListQuery(string type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}

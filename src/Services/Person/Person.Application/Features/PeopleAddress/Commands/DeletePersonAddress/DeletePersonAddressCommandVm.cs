using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Commands.DeletePersonAddress
{
    public class DeletePersonAddressCommandVm : IRequest
    {
        public int ID { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Commands.DeletePerson
{
    public class DeletePersonCommandVm : IRequest
    {
        public int ID { get; set; }
    }
}

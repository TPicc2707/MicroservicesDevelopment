using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Commands.UpdatePersonAddress
{
    public class UpdatePersonAddressCommandVm : IRequest
    {
        public int ID { get; set; }
        public int Person_Id { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

    }
}

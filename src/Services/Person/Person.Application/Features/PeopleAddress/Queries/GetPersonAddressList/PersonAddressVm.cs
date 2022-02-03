using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.PeopleAddress.Queries.GetPersonAddressList
{
    public class PersonAddressVm
    {
        public int Id { get; set; }
        public int Person_Id { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [MaxLength(5, ErrorMessage = "Zip Code must be less than 5 digits")]
        public int ZipCode { get; set; }

    }
}

using Newtonsoft.Json;
using Person.Application.Features.PeopleAddress.Queries;
using Person.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Queries
{
    [JsonObject(IsReference = false)]
    public class PersonViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Rank { get; set; }
        public string Gender { get; set; }
        public float Weight { get; set; }
        public int Height { get; set; }
        public string EyeColor { get; set; }
        public string Race { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PersonAddressVm> Addresses { get; set; }
    }
}

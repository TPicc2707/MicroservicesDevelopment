using Person.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Domain.Entities
{
    public class Person : EntityBase
    {
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
        public List<Person_Address> Addresses { get; set; }
    }
}

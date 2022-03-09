using System.Collections.Generic;

namespace Microservices.WebAssemblyBlazor.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
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
        public ICollection<Person_AddressModel> Addresses { get; set; }
    }
}

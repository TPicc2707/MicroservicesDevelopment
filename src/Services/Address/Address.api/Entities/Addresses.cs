using System.Collections.Generic;

namespace Address.api.Entities
{
    public class Addresses
    {
        public string PersonID { get; set; }
        public List<Address> PersonAddresses { get; set; } = new List<Address>();
        public Addresses()
        {

        }
        public Addresses(string ID)
        {
            PersonID = ID;
        }
    }
}

using System.Collections.Generic;

namespace Microservices.WebAssemblyBlazor.Models
{
    public class AddressesModel
    {
        public string PersonID { get; set; }
        public List<AddressItemModel> PersonAddresses { get; set; } = new List<AddressItemModel>();

    }
}

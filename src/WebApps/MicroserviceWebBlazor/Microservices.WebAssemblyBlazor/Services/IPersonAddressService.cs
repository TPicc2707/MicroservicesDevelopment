using Microservices.WebAssemblyBlazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.WebAssemblyBlazor.Services
{
    public interface IPersonAddressService
    {
        Task<IEnumerable<Person_AddressModel>> GetAddressesByType(string type);
        Task<Person_AddressModel> GetAddressById(string ID);
        Task UpdatePersonAddress(Person_AddressModel personAddress);
        Task DeletePersonAddress(int ID);
    }
}

using Microservices.WebAssemblyBlazor.Models;
using System.Threading.Tasks;

namespace Microservices.WebAssemblyBlazor.Services
{
    public interface IAddressService
    {
        Task<AddressesModel> GetAddresses(string ID);
        Task<AddressesModel> UpdateAddress(AddressesModel model);
        Task CreateAddress(string ID);
    }
}

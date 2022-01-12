using Address.api.Entities;
using System.Threading.Tasks;

namespace Address.api.Repositories
{
    public interface IAddressRepository
    {
        Task<Addresses> GetPersonAddresses(string ID);
        Task<Addresses> UpdatePersonAddress(Addresses address);
        Task DeletePersonAddress(string ID);
    }
}

using Address.api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Address.api.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDistributedCache _redisCache;
        public AddressRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }
        public async Task DeletePersonAddress(string ID)
        {
            await _redisCache.RemoveAsync(ID);
        }

        public async Task<Addresses> GetPersonAddresses(string ID)
        {
            var address = await _redisCache.GetStringAsync(ID);
            if (string.IsNullOrEmpty(address))
                return null;
            return JsonConvert.DeserializeObject<Addresses>(address);
        }

        public async Task<Addresses> UpdatePersonAddress(Addresses address)
        {
            await _redisCache.SetStringAsync(address.PersonID, JsonConvert.SerializeObject(address));
            return await GetPersonAddresses(address.PersonID);
        }
    }
}

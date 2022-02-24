using Microservices.WebAssemblyBlazor.Extensions;
using Microservices.WebAssemblyBlazor.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.WebAssemblyBlazor.Services
{
    public class PersonAddressService : IPersonAddressService
    {
        private readonly HttpClient _client;

        public PersonAddressService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Person_AddressModel>> GetAddressesByType(string type)
        {
            var response = await _client.GetAsync($"/GetAddressesByType/{type}");

            return await response.ReadContentAs<List<Person_AddressModel>>();
        }
    }
}

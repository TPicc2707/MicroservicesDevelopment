using Microservices.WebAssemblyBlazor.Extensions;
using Microservices.WebAssemblyBlazor.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.WebAssemblyBlazor.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _client;

        public AddressService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<AddressesModel> GetAddresses(string ID)
        {
            var response = await _client.GetAsync($"/api/v1/Address/{ID}");
            return await response.ReadContentAs<AddressesModel>();
        }

        public async Task UpdateAddress(AddressesModel model)
        {
            var response = await _client.PostAsJson($"/api/v1/Address", model);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong with calling the api.");
        }

        public async Task CreateAddress(string ID)
        {
            var response = await _client.PostAsJson($"/api/v1/Address/CreateAddress/{ID}", ID);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong with calling the api.");
        }
    }
}

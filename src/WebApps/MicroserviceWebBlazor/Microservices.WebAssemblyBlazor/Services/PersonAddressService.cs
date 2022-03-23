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
        private readonly Navigation _navigation;

        public PersonAddressService(HttpClient client, Navigation navigation)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
        }
        public async Task<Person_AddressModel> GetAddressById(string ID)
        {
            var response = await _client.GetAsync($"api/v1/PersonAddress/GetAddressById/{ID}");

            return await response.ReadContentAs<Person_AddressModel>();
        }
        public async Task<IEnumerable<Person_AddressModel>> GetAddressesByType(string type)
        {
            var response = await _client.GetAsync($"api/v1/PersonAddress/GetAddressesByType/{type}");

            return await response.ReadContentAs<List<Person_AddressModel>>();
        }

        public async Task UpdatePersonAddress(Person_AddressModel person_Address)
        {
            var response = await _client.PutAsJson($"/api/v1/PersonAddress", person_Address);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong with calling the api.");
            _navigation.NavigateBack();
        }
    }
}

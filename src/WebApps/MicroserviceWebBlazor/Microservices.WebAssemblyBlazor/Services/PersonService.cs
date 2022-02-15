using Microservices.WebAssemblyBlazor.Models;
using Microservices.WebAssemblyBlazor.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.WebAssemblyBlazor.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _client;

        public PersonService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<PersonModel>> GetActivePeople(bool isActive)
        {
            var response = await _client.GetAsync($"/Person/GetPeopleByIsActive/{isActive}");
            return await response.ReadContentAs<List<PersonModel>>();
        }

        public async Task<IEnumerable<PersonModel>> GetPeopleByLastName(string lastName)
        {
            var response = await _client.GetAsync($"/Person/GetPeopleByLastName/{lastName}");
            return await response.ReadContentAs<List<PersonModel>>();
        }
    }
}

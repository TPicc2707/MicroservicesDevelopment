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
        private readonly Navigation _navigation;

        public PersonService(HttpClient client, Navigation navigation)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
        }

        public async Task<IEnumerable<PersonModel>> GetPeople()
        {
            var response = await _client.GetAsync($"/api/v1/Person/GetPeople/");
            return await response.ReadContentAs<List<PersonModel>>();
        }
        public async Task<IEnumerable<PersonModel>> GetActivePeople(bool isActive)
        {
            var response = await _client.GetAsync($"/api/v1/Person/GetPeopleByIsActive/{isActive}");
            return await response.ReadContentAs<List<PersonModel>>();
        }


        public async Task<IEnumerable<PersonModel>> GetPeopleByLastName(string lastName)
        {
            var response = await _client.GetAsync($"/api/v1/Person/GetPeopleByLastName/{lastName}");
            return await response.ReadContentAs<List<PersonModel>>();
        }

        public async Task<PersonModel> GetPersonById(string Id)
        {
            var response = await _client.GetAsync($"/api/v1/Person/GetPersonById/{Id}");
            return await response.ReadContentAs<PersonModel>();
        }

        public async Task CreatePerson(PersonModel person)
        {
            var response = await _client.PostAsJson($"/api/v1/Person", person);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong with calling the api.");

        }

        public async Task UpdatePerson(PersonModel person)
        {
            var response = await _client.PutAsJson($"/api/v1/Person", person);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong with calling the api.");
            _navigation.NavigateBack();
        }

        public async Task DeletePerson(int Id)
        {
            var response = await _client.DeleteAsync($"/api/v1/Person/{Id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong with calling the api.");
            //_navigation.NavigateBack();
        }
    }
}

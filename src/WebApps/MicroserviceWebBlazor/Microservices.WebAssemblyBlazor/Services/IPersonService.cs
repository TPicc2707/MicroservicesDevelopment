using Microservices.WebAssemblyBlazor.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.WebAssemblyBlazor.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonModel>> GetActivePeople(bool isActive);
        Task<IEnumerable<PersonModel>> GetPeopleByLastName(string lastName);
        Task CreatePerson(PersonModel person);
        Task<PersonModel> UpdatePerson(PersonModel person);
    }
}

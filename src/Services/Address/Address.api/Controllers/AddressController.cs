using Address.api.Entities;
using Address.api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Address.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }
        [HttpGet("{ID}",Name ="GetAddresses")]
        [ProducesResponseType(typeof(Addresses), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Addresses>> GetAddresses(string ID)
        {
            var addresses = await _addressRepository.GetPersonAddresses(ID);
            return Ok(addresses ?? new Addresses(ID));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Addresses), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Addresses>> UpdateAddress([FromBody] Addresses addresses)
        {
            return Ok(await _addressRepository.UpdatePersonAddress(addresses));
        }

        [HttpDelete("{ID}",Name ="DeleteAddresses")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> DeleteAddresses(string ID)
        {
            await _addressRepository.DeletePersonAddress(ID);
            return Ok();
        }


    }
}

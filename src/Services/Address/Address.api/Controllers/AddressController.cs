using Address.api.Entities;
using Address.api.Repositories;
using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
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
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public AddressController(IAddressRepository addressRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));

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

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAddress(string ID)
        {
            var address = await _addressRepository.GetPersonAddresses(ID);
            if(address == null) 
            { 
                return BadRequest(); 
            }

            foreach(var personAddress in address.PersonAddresses)
            {
                CreatePersonAddress newAddress = new CreatePersonAddress
                {
                    Person_Id = Convert.ToInt32(ID),
                    Type = personAddress.Type,
                    Street = personAddress.Street,
                    City = personAddress.City,
                    State = personAddress.State,
                    ZipCode = personAddress.ZipCode
                };

                var eventMessage = _mapper.Map<CreatePersonAddressEvent>(newAddress);
                await _publishEndpoint.Publish(eventMessage);
            }

            await _addressRepository.DeletePersonAddress(address.PersonID);
            return Accepted();
        }
    }
}

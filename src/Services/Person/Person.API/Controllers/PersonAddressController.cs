using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.Application.Features.PeopleAddress.Commands.CreatePersonAddress;
using Person.Application.Features.PeopleAddress.Commands.UpdatePersonAddress;
using Person.Application.Features.PeopleAddress.Queries;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Person.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonAddressController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("[action]/{type}", Name = "GetAddressesByType")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonAddressVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PersonAddressVm>>> GetAddressesByType(string type)
        {
            var query = new GetPersonAddressListQuery(type);
            var addresses = await _mediator.Send(query);
            return Ok(addresses);
        }

        [HttpPost(Name = "CreatePersonAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreatePersonAddress([FromBody] CreatePersonAddressCommandVm createPersonAddressCommandVm)
        {
            var result = await _mediator.Send(createPersonAddressCommandVm);
            return Ok(result);
        }

        [HttpPut(Name = "UpdatePersonAddress")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePersonAddress([FromBody] UpdatePersonAddressCommandVm updatePersonAddressCommandVm)
        {
            await _mediator.Send(updatePersonAddressCommandVm);
            return NoContent();
        }

        [Route("[action]/{ID}", Name = "GetAddressById")]
        [HttpGet]
        [ProducesResponseType(typeof(PersonAddressVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PersonAddressVm>> GetAddressById(string ID)
        {
            var query = new GetPersonAddressByIdQuery(Convert.ToInt32(ID));
            var address = await _mediator.Send(query);
            return Ok(address);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Person.Application.Features.PeopleAddress.Commands.CreatePersonAddress;
using Person.Application.Features.PeopleAddress.Queries.GetPersonAddressList;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Person.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
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

    }
}

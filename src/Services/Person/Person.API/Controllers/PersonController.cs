using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.Application.Features.People.Commands.CreatePerson;
using Person.Application.Features.People.Commands.DeletePerson;
using Person.Application.Features.People.Commands.UpdatePerson;
using Person.Application.Features.People.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Person.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{isActive}", Name = "GetActivePeople")]
        [ProducesResponseType(typeof(IEnumerable<PersonViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetPeopleByIsActive(bool isActive)
        {
            var query = new GetPersonListQuery(isActive);
            var people = await _mediator.Send(query);
            return Ok(people);
        }

        [HttpGet("{lastName}", Name = "GetPeopleByLastName")]
        [ProducesResponseType(typeof(IEnumerable<PersonViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetPeopleByLastName(string lastName)
        {
            var query = new GetPersonListQuery(lastName);
            var people = await _mediator.Send(query);
            return Ok(people);
        }

        [HttpPost(Name = "CreatePerson")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreatePerson([FromBody] CreatePersonCommandVm createPersonCommandVm)
        {
            var result = await _mediator.Send(createPersonCommandVm);
            return Ok(result);
        }

        [HttpPut(Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>UpdatePerson([FromBody] UpdatePersonCommandVm updatePersonCommandVm)
        {
            await _mediator.Send(updatePersonCommandVm);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var deleteCommand = new DeletePersonCommandVm() { ID = id };
            await _mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}

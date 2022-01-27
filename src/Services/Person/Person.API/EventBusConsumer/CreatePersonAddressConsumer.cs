using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Features.PeopleAddress.Commands.CreatePersonAddress;
using System;
using System.Threading.Tasks;

namespace Person.API.EventBusConsumer
{
    public class CreatePersonAddressConsumer : IConsumer<CreatePersonAddressEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonAddressConsumer> _logger;

        public CreatePersonAddressConsumer(IMediator mediator, IMapper mapper,
            ILogger<CreatePersonAddressConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<CreatePersonAddressEvent> context)
        {
            var command = _mapper.Map<CreatePersonAddressCommandVm>(context.Message);
            var result = await _mediator.Send(command);

            _logger.LogInformation("CreatePersonAddressEvent consumed successfully. Created Person Address Id: {newPersonAddressId}", result);
        }
    }
}

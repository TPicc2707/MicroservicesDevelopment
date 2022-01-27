using AutoMapper;
using EventBus.Messages.Events;
using Person.Application.Features.PeopleAddress.Commands.CreatePersonAddress;

namespace Person.API.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonAddressCommandVm, CreatePersonAddressEvent>().ReverseMap();
        }
    }
}

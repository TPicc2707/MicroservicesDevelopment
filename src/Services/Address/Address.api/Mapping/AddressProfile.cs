using Address.api.Entities;
using AutoMapper;
using EventBus.Messages.Events;

namespace Address.api.Mapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreatePersonAddress, CreatePersonAddressEvent>().ReverseMap();
        }
    }
}

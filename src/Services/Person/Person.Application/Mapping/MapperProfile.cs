using AutoMapper;
using Person.Application.Features.People.Commands.CreatePerson;
using Person.Application.Features.People.Commands.UpdatePerson;
using Person.Application.Features.People.Queries;
using Person.Application.Features.PeopleAddress.Commands.CreatePersonAddress;
using Person.Application.Features.PeopleAddress.Queries.GetPersonAddressList;
using Person.Domain.Entities;


namespace Person.Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Entities.Person, PersonViewModel>().ReverseMap();
            CreateMap<Domain.Entities.Person, CreatePersonCommandVm>().ReverseMap();
            CreateMap<Domain.Entities.Person, UpdatePersonCommandVm>().ReverseMap();

            CreateMap<Person_Address, PersonAddressVm>().ReverseMap();
            CreateMap<Person_Address, CreatePersonAddressCommandVm>().ReverseMap();
        }
    }
}

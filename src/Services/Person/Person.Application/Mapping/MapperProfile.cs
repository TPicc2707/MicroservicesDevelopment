using AutoMapper;
using Person.Application.Features.People.Commands.CreatePerson;
using Person.Application.Features.People.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Entities.Person, PersonViewModel>().ReverseMap();
            CreateMap<Domain.Entities.Person, UpdatePersonCommandVm>().ReverseMap();
        }
    }
}

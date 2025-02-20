using AutoMapper;
using Persons.API.Database.Entities;
using Persons.API.Dtos.Persons;

namespace Persons.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Pasa de un personEntity a un PersonDto
            CreateMap<PersonEntity, PersonDto>(); //Origen, Destino (los atributos que tenga personEntity lo usara PersonDto)
            
            CreateMap<PersonEntity, PersonActionResponseDto>();

            CreateMap<PersonCreateDto, PersonEntity>();

            //Para Editar
            CreateMap<PersonEditDto, PersonEntity>();

        }
    }
}

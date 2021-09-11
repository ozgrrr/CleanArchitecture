using AutoMapper;
using CleanArchitecture.Application.Common.Mapper;
using Entities = CleanArchitecture.Domain.Entities.User;

namespace CleanArchitecture.Application.Methods.Person.Queries.GetAllPersons
{
    public class PersonDto : IMapFrom<Entities.Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Person, PersonDto>();
        }
    }
}

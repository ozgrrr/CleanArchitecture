using CleanArchitecture.Application.Common.Dto.Default;
using MediatR;

namespace CleanArchitecture.Application.Methods.Person.Command.UpdatePerson
{
    public class UpdatePersonCommand : IRequest<DefaultResponse<PersonDto>>
    {
#nullable enable
        public int personId { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
#nullable disable
    }
}

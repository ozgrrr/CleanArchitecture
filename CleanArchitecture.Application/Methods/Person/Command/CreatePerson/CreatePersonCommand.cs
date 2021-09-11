using AltamiraTask.Application.Methods.Person.Command.CreatePerson;
using CleanArchitecture.Application.Common.Dto.Default;
using MediatR;

namespace CleanArchitecture.Application.Methods.Person.Command.CreatePerson
{
    public class CreatePersonCommand : IRequest<DefaultResponse<PersonDto>>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

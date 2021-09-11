using MediatR;

namespace CleanArchitecture.Application.Methods.Person.Command.Auth
{
    public class AuthCommand : IRequest<AuthVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

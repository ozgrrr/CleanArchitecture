using CleanArchitecture.Application.Common.Dto.Default;
using MediatR;

namespace CleanArchitecture.Application.Methods.Person.Command.DeletePerson
{
    public class DeletePersonCommand : IRequest<DefaultResponse>
    {
        public int PersonId{ get; set; }
    }
}

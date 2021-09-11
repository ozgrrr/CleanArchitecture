using CleanArchitecture.Application.Common.Dto.Default;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Methods.Person.Queries.GetAllPersons
{
    public class GetAllPersonsQuery : IRequest<DefaultResponse<List<PersonDto>>>
    {
    }
}

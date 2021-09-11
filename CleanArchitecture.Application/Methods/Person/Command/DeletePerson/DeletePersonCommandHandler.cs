using AutoMapper;
using CleanArchitecture.Application.Common.Dto.Default;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Methods.Person.Command.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, DefaultResponse>
    {
        private readonly IAtDbContext _context;
        private readonly IMapper _mapper;

        public DeletePersonCommandHandler(IAtDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await DeletePerson(request, cancellationToken);
        }

        public async Task<DefaultResponse> DeletePerson(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var response = new DefaultResponse();
            response.Result = 0;
            response.Success = false;
            response.ResultText = "";

            var person = await _context.Persons.Where(s => s.Id == request.PersonId &&
                                                           s.Active &&
                                                           !s.Deleted)
                                               .FirstOrDefaultAsync();

            if (person != null)
            {
                person.Active = false;
                person.Deleted = true;

                _context.Persons.Update(person);
                await _context.SaveChangesAsync(cancellationToken);

                response.Result = 1;
                response.ResultText = "The person is successfully deleted";
                response.Success = true;
            }
            else
            {
                response.ResultText = "Person can not be found";
            }

            return response;
        }
    }
}

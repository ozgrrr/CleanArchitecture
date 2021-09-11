using AutoMapper;
using CleanArchitecture.Application.Common.Dto.Default;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Methods.Person.Command.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, DefaultResponse<PersonDto>>
    {
        private readonly IAtDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IAtDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DefaultResponse<PersonDto>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return await UpdatePerson(request, cancellationToken);
        }

        public async Task<DefaultResponse<PersonDto>> UpdatePerson(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var response = new DefaultResponse<PersonDto>();
            response.Success = false;
            response.ResultText = "";

            var person = await _context.Persons.Where(s => s.Id == request.personId &&
                                                           s.Active &&
                                                           !s.Deleted)
                                               .FirstOrDefaultAsync();

            if (person != null)
            {
                if (request.Name != null)
                {
                    person.Name = request.Name;
                }
                if (request.Username != null)
                {
                    person.Username = request.Username;
                }
                if (request.Email != null)
                {
                    person.Email = request.Email;
                }
                if (request.Password != null)
                {
                    person.Password = request.Password;
                }

                _context.Persons.Update(person);
                await _context.SaveChangesAsync(cancellationToken);

                response.Success = true;
                response.ResultText = "Person information is successfully updated";
                response.Result = _mapper.Map<PersonDto>(person);

            }
            else
            {
                response.ResultText = "Person could not be found";
            }

            return response;
        }
    }
}

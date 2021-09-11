using AltamiraTask.Application.Methods.Person.Command.CreatePerson;
using AutoMapper;
using CleanArchitecture.Application.Common.Dto.Default;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Methods.Person.Command.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, DefaultResponse<PersonDto>>
    {
        private readonly IAtDbContext _context;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IAtDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DefaultResponse<PersonDto>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            return await CreatePerson(request, cancellationToken);
        }

        public async Task<DefaultResponse<PersonDto>> CreatePerson(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var response = new DefaultResponse<PersonDto>();
            response.Success = false;
            response.ResultText = "";

            try
            {
                var person = await _context.Persons.Where(s => (s.Username == request.Username ||
                                                            s.Email == request.Email) &&
                                                            s.Active &&
                                                            !s.Deleted)
                                               .FirstOrDefaultAsync();

                if (person != null)
                {
                    response.ResultText = "This username or email can not bu used";

                    return response;
                }
                else
                {
                    var newPerson = new Domain.Entities.User.Person()
                    {
                        Name = request.Name,
                        Username = request.Username,
                        Email = request.Email,
                        Password = request.Password,
                        Active = true,
                        Deleted = false,
                    };

                    await _context.Persons.AddAsync(newPerson);
                    await _context.SaveChangesAsync(cancellationToken);

                    response.ResultText = "New person is succesfully created";
                    response.Success = true;
                    response.Result = _mapper.Map<PersonDto>(newPerson);

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ResultText = $"Error Message: {ex.Message}\n" +
                                      $"Inner Exception: {ex.InnerException}";
                return response;
            }
        }
    }
}

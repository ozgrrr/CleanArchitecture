using CleanArchitecture.Application.Common.Auth;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Methods.Person.Command.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthVm>
    {
        private IAtDbContext _context;
        private IJwtFactory _jwtFactory;

        public AuthCommandHandler(IAtDbContext context, IJwtFactory jwtFactory)
        {
            _context = context;
            _jwtFactory = jwtFactory;
        }

        public async Task<AuthVm> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            return await Auth(request, cancellationToken);
        }

        public async Task<AuthVm> Auth(AuthCommand request, CancellationToken cancellationToken)
        {
            var vm = new AuthVm();
            var person = await _context.Persons.Where(s => s.Email == request.Email &&
                                                           s.Password == request.Password &&
                                                           s.Active &&
                                                           !s.Deleted)
                                                .FirstOrDefaultAsync();

            if (person != null)
            {
                var token = await _jwtFactory.GenerateEncodedToken(person.Id, request.Email);

                vm.PersonId = person.Id.ToString(); 
                vm.Token = token.AuthToken;
            }

            return vm;
        }
    }
}

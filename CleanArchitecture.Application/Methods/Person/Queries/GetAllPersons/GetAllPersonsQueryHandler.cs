using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Dto.Default;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Methods.Person.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, DefaultResponse<List<PersonDto>>>
    {
        private readonly IAtDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPersonsQueryHandler(IAtDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DefaultResponse<List<PersonDto>>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return await GetAllPersons(request, cancellationToken);
        }

        private async Task<DefaultResponse<List<PersonDto>>> GetAllPersons(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var response = new DefaultResponse<List<PersonDto>>();
            response.ResultText = "";
            response.Success = false;

            var persons = await _context.Persons.Where(s => s.Active &&
                                                            !s.Deleted)
                                                .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
                                                .ToListAsync();

            if (persons.Count > 0)
            {
                response.Result = persons;
                response.Success = true;
                response.ResultText = "Success";
            }
            else
            {
                response.ResultText = "No person is found";
            }

            return response;
        }
    }
}

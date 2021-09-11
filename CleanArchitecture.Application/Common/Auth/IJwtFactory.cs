using CleanArchitecture.Application.Common.Dto.Auth;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Auth
{
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(int id, string userName);
    }
}

using CleanArchitecture.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IAtDbContext
    {
        #region Person
        public DbSet<Person> Persons { get; set; }
        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
        DatabaseFacade Database { get; }
    }
}

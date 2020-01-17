using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactMapApi.Data
{
    public partial interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
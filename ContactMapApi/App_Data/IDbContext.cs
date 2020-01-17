using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.App_Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactMapApi.App_Data
{
    public partial interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
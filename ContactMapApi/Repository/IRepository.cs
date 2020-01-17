using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Data.Entities;

namespace ContactMapApi.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }

        Task<TEntity> GetByIdAsync(object id, CancellationToken token = default);

        Task<int> InsertAsync(TEntity entity, bool saveChanges = true, CancellationToken token = default);

        Task<int> InsertAsync(IList<TEntity> entities, bool saveChanges = true, CancellationToken token = default);

        Task<int> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken token = default);

        Task<int> DeleteAsync(IList<TEntity> entities, bool saveChanges = true, CancellationToken token = default);

        Task<int> SaveChangesAsync(CancellationToken token = default);

    }
}
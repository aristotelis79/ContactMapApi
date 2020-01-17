using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.App_Data.Entities;

namespace ContactMapApi.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }

        Task<TEntity> GetByIdAsync(object id, CancellationToken token = default);

        Task<int> InsertAsync(TEntity entity,CancellationToken token = default, bool saveChanges = true );

        Task<int> InsertAsync(IList<TEntity> entities,CancellationToken token = default, bool saveChanges = true );

        Task<int> DeleteAsync(TEntity entity,CancellationToken token = default, bool saveChanges = true );

        Task<int> DeleteAsync(IList<TEntity> entities,CancellationToken token = default, bool saveChanges = true );

        Task<int> SaveChangesAsync(CancellationToken token = default);

    }
}
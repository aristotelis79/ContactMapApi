using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContactMapApi.Data;
using ContactMapApi.Data.Entities;
using ContactMapApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ContactMapApi.Repository
{
    public partial class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly IDbContext _context;

        private DbSet<TEntity> _entities;

        #endregion

        #region Properties

        public virtual IQueryable<TEntity> Table => Entities;


        protected virtual DbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());

        #endregion

        #region Ctor

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public virtual async Task<TEntity> GetByIdAsync(object id, CancellationToken token = default)
        {
            return await Entities.FindAsync(new object[]{id},token)
                                    .ConfigureAwait(false);
        }

        public virtual async Task<int> InsertAsync(TEntity entity, bool saveChanges = true, CancellationToken token = default)
        {
            entity.CheckForNull();

            try
            {
                await Entities.AddAsync(entity,token).ConfigureAwait(false);

                if (!saveChanges) return 0;

                return await _context.SaveChangesAsync(token).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual async Task<int> InsertAsync(IList<TEntity> entities, bool saveChanges = true, CancellationToken token = default)
        {
            entities.CheckForNull();

            try
            {
                await Entities.AddRangeAsync(entities,token).ConfigureAwait(false);

                if (!saveChanges) return 0;

                return await _context.SaveChangesAsync(token).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual async Task<int> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken token = default)
        {
            entity.CheckForNull();
         
            try
            {
                Entities.Remove(entity);

                if (!saveChanges) return 0;

                return await _context.SaveChangesAsync(token).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }
        
        public virtual async Task<int> DeleteAsync(IList<TEntity> entities, bool saveChanges = true, CancellationToken token = default)
        {
            entities.CheckForNull();

            try
            {
                Entities.RemoveRange(entities);

                if (!saveChanges) return 0;

                return await _context.SaveChangesAsync(token).ConfigureAwait(false);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return await _context.SaveChangesAsync(token).ConfigureAwait(false);
        }
        #endregion

        #region Utilities

        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }
            
            try
            { 
                var result =  _context.SaveChangesAsync().Result;
                return exception.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString(); 
            }
        }

        #endregion
    }
}
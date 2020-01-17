using ContactMapApi.App_Data.Entities;
using ContactMapApi.App_Data.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ContactMapApi.App_Data
{
    public class ContactMapDbContext: DbContext , IDbContext
    {
        #region Fields

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Address> Address { get; set; }

        #endregion

        #region ctor


        public ContactMapDbContext(DbContextOptions<ContactMapDbContext> options) : base(options)
        {
        }

        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());

            base.OnModelCreating(modelBuilder);

        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        #endregion
    }
}
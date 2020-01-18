using ContactMapApi.App_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactMapApi.App_Data.EntityTypeConfigurations
{
    public class AddressConfiguration :IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address)).HasKey(k => k.Id);

            builder.Property(p => p.RoadName).IsRequired();
            builder.Property(p => p.RoadNumber).IsRequired();
            builder.Property(p => p.ZipCode).IsRequired();
            builder.Property(p => p.Country).IsRequired();
            builder.Property(p => p.City).IsRequired();

            builder.HasOne(x => x.Contact)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.ContactId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
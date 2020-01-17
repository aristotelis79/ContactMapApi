using ContactMapApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactMapApi.Data.EntityTypeConfigurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(nameof(Contact)).HasKey(k => k.Id);

            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(14);


        }
    }
}
using eOrder.Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eOrder.Infra.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("bigint");

            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Email)
                .HasColumnType("nvarchar(320)");

            builder.Property(p => p.CustomerId)
                .HasColumnType("bigint");

            builder.Property(p => p.ReceiveMail)
                .HasColumnType("bit");
        }
    }
}

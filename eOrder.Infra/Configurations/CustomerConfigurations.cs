using eOrder.Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eOrder.Infra.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasIndex(x => x.Document)
                .IsClustered(false);

            builder.HasIndex(x => x.Code)
                .IsClustered(false);

            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Document)
                .HasColumnType("nvarchar(20)");

            builder.Property(p => p.Code)
                .HasColumnType("nvarchar(40)");

            builder.Property(p => p.IsActive)
                .HasColumnType("bit");


            builder.HasMany(x => x.Contacts)
                .WithOne()
                .HasForeignKey("CustomerId");

        }
    }
}

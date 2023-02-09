using eOrder.Domain.Rules.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eOrder.Infra.Configurations
{
    public class RuleConfiguration : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            builder.ToTable("Rules");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(30)");

            builder.Property(p => p.Description)
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Group)
                .HasColumnType("nvarchar(20)");

            builder.Property(p => p.Index)
                .HasColumnType("int");

            builder.Property(p => p.RunOnNews)
                .HasColumnType("bit");

            builder.Property(p => p.RunOnModification)
                .HasColumnType("bit");

            builder.Property(p => p.SituationOnApprove)
                .HasColumnType("nvarchar(40)");

            builder.Property(p => p.SituationOnDisapprove)
                .HasColumnType("nvarchar(40)");

            builder.Property(p => p.ParameterType)
                .HasColumnType("nvarchar(40)");

            builder.Property(p => p.ParameterOption)
                .HasColumnType("nvarchar(40)");

        }
    }
}

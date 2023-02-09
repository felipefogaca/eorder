using eOrder.Domain.DayOffs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Infra.Configurations
{
    public class DayOffConfiguration : IEntityTypeConfiguration<DayOff>
    {
        public void Configure(EntityTypeBuilder<DayOff> builder)
        {
            builder.ToTable("DayOffs");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(100)");

            builder.Property(p => p.Date)
                .HasColumnType("date");
        }
    }
}

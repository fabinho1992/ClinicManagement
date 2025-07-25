using ClinicManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).
                HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Value)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(350)
                .IsRequired();

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.HasMany(x => x.Consults)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

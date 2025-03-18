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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street).HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.City).HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.State)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.ZipCode)
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(a => a.Complement).HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.PatientId)
                .IsRequired(false);

            builder.Property(a => a.DoctorId)
                .IsRequired(false);

            builder.Property(t => t.TypeUser)
               .HasConversion<string>()
               .IsRequired();
        }
    }
}

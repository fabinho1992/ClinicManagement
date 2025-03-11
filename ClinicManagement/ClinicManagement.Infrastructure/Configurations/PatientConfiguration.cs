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
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
           .IsRequired()
           .HasMaxLength(200); 

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasMaxLength(20); 

            builder.Property(x => x.Email)
                .HasMaxLength(200); 

            builder.Property(x => x.Cpf)
                .HasMaxLength(14); 

            builder.Property(x => x.Height)
                .IsRequired();

            builder.Property(x => x.Weight)
                .IsRequired();

            builder.HasMany(x => x.Treatments)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

            builder.HasOne(s => s.Address)
                .WithOne(a => a.Patient)
                .HasForeignKey<Address>(a => a.PatientId);

            builder.Property(t => t.BloodType)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}

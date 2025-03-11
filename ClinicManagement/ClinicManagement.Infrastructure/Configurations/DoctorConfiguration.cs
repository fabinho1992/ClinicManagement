﻿using ClinicManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
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

            builder.Property(x => x.CRM)
                .IsRequired();

            builder.HasMany(x => x.Treatments)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId);

            builder.HasOne(s => s.Address)
                .WithOne(a => a.Doctor)
                .HasForeignKey<Address>(a => a.DoctorId);

            builder.Property(t => t.BloodType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(t => t.Specialty)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}

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
    public class ConsultConfiguration : IEntityTypeConfiguration<Consult>
    {
        public void Configure(EntityTypeBuilder<Consult> builder)
        {
            builder.HasKey(t => t.Id);

            builder.ToTable("Consults");

            builder.Property(t => t.TypeTreatment)
                .HasConversion<string>()
                .IsRequired();

        }
    }
}

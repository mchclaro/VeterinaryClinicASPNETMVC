using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
  internal class VeterinaryConfiguration : IEntityTypeConfiguration<Veterinary>
  {
    public void Configure(EntityTypeBuilder<Veterinary> builder)
    {
      builder.ToTable("Veterinary");
      builder.HasKey(e => e.Id);

      builder.Property(e => e.Name)
          .IsRequired(false)
          .HasMaxLength(255);
    }
  }
}
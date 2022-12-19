using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
  internal class AnimalConfiguration : IEntityTypeConfiguration<Animal>
  {
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
      builder.ToTable("Animal");
      builder.HasKey(e => e.Id);

      builder.Property(e => e.Name)
          .IsRequired(false)
          .HasMaxLength(255);

      builder.Property(e => e.Breed)
            .IsRequired(false)
            .HasMaxLength(255);

      builder.Property(e => e.Age)
              .IsRequired(false)
              .HasMaxLength(10);
    }
  }
}
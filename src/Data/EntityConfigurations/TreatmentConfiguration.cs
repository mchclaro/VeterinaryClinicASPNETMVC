using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
  internal class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
  {
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
      builder.ToTable("Treatment");
      builder.HasKey(e => e.Id);

      builder.Property(e => e.Comment)
          .IsRequired(false)
          .HasMaxLength(255);

      builder.HasOne(e => e.Animal)
                 .WithOne(x => x.Treatment)
                 .HasForeignKey<Treatment>(e => e.Animal)
                 .OnDelete(DeleteBehavior.NoAction);

      builder.HasOne(e => e.Veterinary)
                   .WithOne(x => x.Treatment)
                   .HasForeignKey<Treatment>(e => e.Veterinary)
                   .OnDelete(DeleteBehavior.NoAction);
    }
  }
}
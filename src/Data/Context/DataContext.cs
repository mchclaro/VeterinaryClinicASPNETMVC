using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Animal> Animal { get; set; }
    public DbSet<Treatment> Treatment { get; set; }
    public DbSet<Veterinary> Veterinary { get; set; }
  }
}
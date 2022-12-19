using Data.Context;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
  public class TreatmentRepository : ITreatmentRepository
  {
    readonly DataContext _context;
    public TreatmentRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<int> Create(Treatment treatment)
    {
      await _context.Treatment.AddAsync(treatment);
      await _context.SaveChangesAsync();

      return treatment.Id;
    }

    public async Task Delete(int id)
    {
      var treatment = _context.Treatment.FirstOrDefault(x => x.Id == id);

      if (treatment == null)
        return;

      _context.Treatment.Remove(treatment);

      await _context.SaveChangesAsync();
    }

    public async Task<Treatment> Read(int id)
    {
      var res = await _context.Treatment
          .Include(x => x.Animal)
          .Include(x => x.Veterinary)
          .Select(x => new Treatment
          {
            Id = x.Id,
            Comment = x.Comment,
            Animal = new Animal
            {
              Name = x.Animal.Name,
              Breed = x.Animal.Breed,
              Age = x.Animal.Age,
            },
            Veterinary = new Veterinary
            {
              Name = x.Veterinary.Name
            }
          }).FirstOrDefaultAsync(x => x.Id == id);

      return res;
    }

    public async Task<IList<Treatment>> ReadAll()
    {
      return await _context.Treatment
          .Include(x => x.Animal)
          .Include(x => x.Veterinary)
          .ToListAsync();
    }

    public async Task Update(Treatment treatment)
    {
      var treat = await _context.Treatment.FindAsync(treatment.Id);
      if (treat != null)
      {
        treat.Comment = treat.Comment;
      }

      var animal = await _context.Animal.FindAsync(treat.AnimalId);
      if (animal != null)
      {
        animal.Name = treatment.Animal.Name;
        animal.Breed = treatment.Animal.Breed;
        animal.Age = treatment.Animal.Age;
      }

      var veteri = await _context.Veterinary.FindAsync(treat.VeterinaryId);
      if (veteri != null)
      {
        veteri.Name = treatment.Veterinary.Name;
      }

      await _context.SaveChangesAsync();
    }
  }
}

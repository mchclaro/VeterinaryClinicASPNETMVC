using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
  public class AnimalRepository : IAnimalRepository
  {
    readonly DataContext _context;
    public AnimalRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<int> Create(Animal animal)
    {
      await _context.Animal.AddAsync(animal);
      await _context.SaveChangesAsync();

      return animal.Id;
    }

    public async Task Delete(int id)
    {
      var animal = _context.Animal.FirstOrDefault(x => x.Id == id);

      if (animal == null)
        return;

      _context.Animal.Remove(animal);

      await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
      var res = await _context.Animal
          .AnyAsync(c => c.Id == id);

      return res;
    }

    public async Task<Animal> Read(int id)
    {
      return await _context.Animal
          .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IList<Animal>> ReadAll()
    {
      return await _context.Animal
          .ToListAsync();
    }

    public async Task Update(Animal animal)
    {
      var res = await _context.Animal.FirstOrDefaultAsync(c => c.Id == animal.Id);

      if (res == null)
        return;

      res.Name = animal.Name;
      res.Breed = animal.Breed;
      res.Age = animal.Age;

      await _context.SaveChangesAsync();
    }
  }
}

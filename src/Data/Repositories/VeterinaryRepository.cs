using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
  public class VeterinaryRepository : IVeterinaryRepository
  {
    readonly DataContext _context;
    public VeterinaryRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<int> Create(Veterinary veterinary)
    {
      await _context.Veterinary.AddAsync(veterinary);
      await _context.SaveChangesAsync();

      return veterinary.Id;
    }

    public async Task Delete(int id)
    {
      var veterinary = _context.Veterinary.FirstOrDefault(x => x.Id == id);

      if (veterinary == null)
        return;

      _context.Veterinary.Remove(veterinary);

      await _context.SaveChangesAsync();
    }

    public async Task<Veterinary> Read(int id)
    {
      return await _context.Veterinary
          .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IList<Veterinary>> ReadAll()
    {
      return await _context.Veterinary
          .ToListAsync();
    }

    public async Task Update(Veterinary veterinary)
    {
      var res = await _context.Veterinary.FirstOrDefaultAsync(c => c.Id == veterinary.Id);

      if (res == null)
        return;

      res.Name = veterinary.Name;

      await _context.SaveChangesAsync();
    }
  }
}

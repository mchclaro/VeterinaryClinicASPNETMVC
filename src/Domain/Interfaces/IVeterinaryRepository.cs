using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IVeterinaryRepository
  {
    Task<int> Create(Veterinary veterinary);
    Task<Veterinary> Read(int id);
    Task<IList<Veterinary>> ReadAll();
    Task Update(Veterinary veterinary);
    Task Delete(int id);
  }
}

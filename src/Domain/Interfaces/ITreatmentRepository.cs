using Domain.Entities;

namespace Domain.Interfaces
{
  public interface ITreatmentRepository
  {
    Task<int> Create(Treatment treatment);
    Task<Treatment> Read(int id);
    Task<IList<Treatment>> ReadAll();
    Task Update(Treatment treatment);
    Task Delete(int id);
  }
}

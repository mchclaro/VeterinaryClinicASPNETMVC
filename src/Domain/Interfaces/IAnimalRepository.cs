﻿
using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IAnimalRepository
  {
    Task<int> Create(Animal animal);
    Task<Animal> Read(int id);
    Task<IList<Animal>> ReadAll();
    Task Update(Animal animal);
    Task<bool> Exists(int id);
    Task Delete(int id);
  }
}

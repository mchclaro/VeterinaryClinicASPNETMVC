using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Animal
{
  public class ListAnimalDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
  }
}
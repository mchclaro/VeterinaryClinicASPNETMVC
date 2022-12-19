using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO.Treatment
{
  public class ListTreatmentDTO
  {
    public int Id { get; set; }
    public string Comment { get; set; }
    public int AnimalId { get; set; }
    public int VeterinaryId { get; set; }
    public virtual Domain.Entities.Animal Animal { get; set; }
    public virtual Domain.Entities.Veterinary Veterinary { get; set; }
  }
}
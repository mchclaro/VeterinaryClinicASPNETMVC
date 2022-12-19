using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Domain.Entities
{
  public class Treatment
  {
    public int Id { get; set; }
    public string Comment { get; set; }
    [Required(ErrorMessage = "Informe o ID do animal")]
    public int AnimalId { get; set; }
    [Required(ErrorMessage = "Informe o ID do veterinário")]
    public int VeterinaryId { get; set; }
    public virtual Animal Animal { get; set; }
    public virtual Veterinary Veterinary { get; set; }
  }
}

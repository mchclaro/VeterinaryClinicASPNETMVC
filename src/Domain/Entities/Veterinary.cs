using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
  public class Veterinary
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome do veterinário")]
    public string Name { get; set; }
    public virtual Treatment Treatment { get; set; }
  }
}

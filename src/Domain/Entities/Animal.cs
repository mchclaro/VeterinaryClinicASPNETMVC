using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
  public class Animal
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Informe o nome do animal")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Informe a raça do animal")]
    public string Breed { get; set; }
    [Required(ErrorMessage = "Informe a idade do animal")]
    public int Age { get; set; }
    public virtual Treatment Treatment { get; set; }
  }
}

using System.ComponentModel.DataAnnotations;

namespace EF.Training.Application.DTO;

public class CreateUserDto
{
  [Required]
  public string Name { get; set; }

  [Range(0, int.MaxValue)]
  public int Age { get; set; }
}
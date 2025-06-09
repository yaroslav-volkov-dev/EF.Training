using System.ComponentModel.DataAnnotations;

namespace EF.Training.Application.DTO;

public class CreateOrderDto
{
  [Required]
  public string Name { get; set; }

  [Required]
  public string Description { get; set; }

  [Range(0, int.MaxValue)]
  public int UserId { get; set; }
}
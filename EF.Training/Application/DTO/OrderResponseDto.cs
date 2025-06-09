namespace EF.Training.Application.DTO;

public class OrderResponseDto
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public int UserId { get; set; }
  public UserResponseDto User { get; set; } // ← Вложенный объект User
  public DateTime CreatedAt { get; set; }
}
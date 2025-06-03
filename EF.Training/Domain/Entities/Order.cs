namespace EF.Training.Domain.Entities;

public class Order
{
  public Order(int userId, string name, string description)
  {
    if (!int.IsPositive(userId))
    {
      throw new ArgumentException("User must be a positive integer");
    }

    UserId = userId;
    Name = name;
    Description = description;
  }

  public int Id { get; private set; }
  public int UserId { get; private set; }
  public User User { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }


  public void UpdateName(string newName)
  {
    if (string.IsNullOrWhiteSpace(newName))
    {
      throw new ArgumentException("Name cannot be empty");
    }

    Name = newName;
  }

  public void UpdateDescription(string newDescription)
  {
    Description = newDescription;
  }

  public void ChangeUser(int newUserId)
  {
    if (newUserId <= 0)
    {
      throw new ArgumentException("User must be a positive integer");
    }

    UserId = newUserId;
  }
}
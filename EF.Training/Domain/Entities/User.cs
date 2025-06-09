namespace EF.Training.Domain.Entities;

public class User
{
  public User(string name, int age)
  {
    if (string.IsNullOrWhiteSpace(name))
      throw new ArgumentException("Name is required");

    if (age < 0)
      throw new ArgumentOutOfRangeException(nameof(age), "Age must be a positive number");

    Name = name;
    Age = age;
  }

  public int Id { get; private set; }
  public string Name { get; private set; }
  public int Age { get; private set; }
  public List<Company> Companies { get; private set; } = [];
  public List<Order> Orders { get; private set; } = [];
}
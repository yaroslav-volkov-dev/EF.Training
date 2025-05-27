using EF.Training.Models;

namespace EF.Training.Services;

public class UserService
{
    public void GetAllUsers()
    {
        using ApplicationContext db = new ();
        List<User> users = db.Users.ToList();
        
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id}. {user.Name} - {user.Age}");
        }
    }
    
    public void AddUser()
    {
        using ApplicationContext db = new ();

        Console.Write("Please enter user name: ");
        string? name = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        
        Console.Write("Please enter user age: ");
        string? inputAge = Console.ReadLine();
        
        if (!int.TryParse(inputAge, out int age))
        {
            throw new ArgumentException(nameof(age));
        }


        db.Users.Add(new User { Name = name, Age = age });
        db.SaveChanges();

        Console.WriteLine("User added");
    }

    public void DeleteUser()
    {
        using ApplicationContext db = new ();
        Console.Write("Please enter user ID ");
        
        Console.Write("Please enter user age: ");
        string? inputId = Console.ReadLine();
        
        if (!int.TryParse(inputId, out int id))
        {
            throw new ArgumentException(nameof(id));
        }

        User? user = db.Users.Find(id);

        if (user is null)
        {
            Console.WriteLine("There is no such user with the given ID. Try again");
            return;
        }
        
        db.Users.Remove(user);
        db.SaveChanges();
        Console.WriteLine("User deleted");
    }
}
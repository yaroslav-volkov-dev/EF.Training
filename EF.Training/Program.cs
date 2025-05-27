using EF.Training.Services;

class Program 
{
    static Task Main()
    {
        
        UserService service = new ();

        while (true)
        {
            Console.WriteLine("Select an action");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "GET":
                    service.GetAllUsers();
                    break;
                case "POST":
                    service.AddUser();
                    break;
                case "DELETE":
                    service.DeleteUser();
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }
        }
    }
}
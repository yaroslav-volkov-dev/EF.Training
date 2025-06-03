using EF.Training.Application.Interfaces;
using EF.Training.Application.Services;
using EF.Training.Infrastructure;
using EF.Training.Infrastructure.Interfaces;
using EF.Training.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

internal class Program
{
  public static void Main(string[] args)
  {
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<ApplicationContext>(options =>
      options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IOrdersService, OrdersService>();
    builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

    builder.Services.AddControllers();

    WebApplication app = builder.Build();

    app.MapControllers();
    app.Run();
  }
}
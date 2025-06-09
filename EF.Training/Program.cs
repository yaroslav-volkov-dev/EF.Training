using EF.Training.Application.Interfaces;
using EF.Training.Application.Mappings;
using EF.Training.Application.Services;
using EF.Training.Infrastructure.Data;
using EF.Training.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

namespace EF.Training;

internal class Program
{
  public static void Main(string[] args)
  {
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<ApplicationContext>(options =>
      options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddApiVersioning(options =>
    {
      options.DefaultApiVersion = new ApiVersion(1, 0);
      options.AssumeDefaultVersionWhenUnspecified = true;
      options.ReportApiVersions = true;

      options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new UrlSegmentApiVersionReader()
      );
    });

    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IOrdersService, OrdersService>();
    builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
    builder.Services.AddScoped<IApplicationContext, ApplicationContext>();
    builder.Services.AddAutoMapper(typeof(OrdersMappingProfile));
    builder.Services.AddAutoMapper(typeof(UserMappingProfile));

    builder.Services.AddControllers();

    WebApplication app = builder.Build();
    app.MapControllers();
    app.Run();
  }
}
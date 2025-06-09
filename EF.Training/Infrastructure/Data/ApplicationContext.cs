using EF.Training.Application.Interfaces;
using EF.Training.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.Training.Infrastructure.Data;

public class ApplicationContext : DbContext, IApplicationContext
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
  public DbSet<Company> Companies { get; set; }
  public DbSet<Order> Orders { get; set; }
}
using EF.Training.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.Training.Infrastructure;

public class ApplicationContext : DbContext
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
  public DbSet<Company> Companies { get; set; }
  public DbSet<Order> Orders { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>()
      .HasMany(user => user.Companies)
      .WithMany(company => company.Users)
      .UsingEntity(builder => builder.ToTable("UserCompanies"));

    modelBuilder.Entity<Order>()
      .HasOne(order => order.User)
      .WithMany(user => user.Orders)
      .HasForeignKey(order => order.UserId);
  }
}
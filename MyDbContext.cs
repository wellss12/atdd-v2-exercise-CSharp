using ATDD.V2.Exercise.CSharp.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ATDD.V2.Exercise.CSharp;

public class MyDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public MyDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_configuration.GetConnectionString("MySql")!);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);

        modelBuilder.Entity<User>().Property(t => t.UserName).HasColumnName("user_name");
        base.OnModelCreating(modelBuilder);
    }
}

public class User
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
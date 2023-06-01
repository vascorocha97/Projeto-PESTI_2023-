using Microsoft.EntityFrameworkCore;
using PESTI_MinimalAPIs.Models;

namespace PESTI_MinimalAPIs.Data;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(DbContextOptions options, IConfiguration configuration):base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_configuration["Database:ConnectionString"]);
    }
    
    public DbSet<User> Users { get; set; }
}
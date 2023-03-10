using C1CopyMudBlazor.Data;
using C1CopyMudBlazor.Data.Entities;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace C1CopyMudBlazor.Data;
public class ApplicationContext : DbContext
{
    public DbSet<Account> Account { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<LegalEntities> LegalEntities { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Tech> Teches { get; set; }
    public DbSet<WorkPlace> WorkPlaces { get; set; }
    public DbSet<IdentityUser> Accounts { get; set; }


    public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions)
        : base(contextOptions)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    private string? connectionString;
    public ApplicationContext(string? connectionString)
    {
        this.connectionString = connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (connectionString !=null)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
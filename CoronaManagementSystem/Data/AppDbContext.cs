using CoronaManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace CoronaManagementSystem.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(){}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Vaccination> Vaccinations { get; set; }
    public DbSet<UserVaccination>  UserVaccinations{ get; set; }

}

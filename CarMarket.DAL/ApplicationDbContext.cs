using CarMarket.Domain.Entity_Models_;
using Microsoft.EntityFrameworkCore;

namespace CarMarket.DAL;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Car> Car { get; set; }
}
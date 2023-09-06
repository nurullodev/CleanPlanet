using Microsoft.EntityFrameworkCore;

namespace CleanPlanet.DAL.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}
using EntregaDispositivosMoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace EntregaDispositivosMoveis.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Entrega> Entregas => Set<Entrega>();
}

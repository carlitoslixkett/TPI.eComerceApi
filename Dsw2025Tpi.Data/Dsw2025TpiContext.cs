using Microsoft.EntityFrameworkCore;
using Dsw2025Tpi.Domain.Entities;

namespace Dsw2025Tpi.Data;

public class Dsw2025TpiContext: DbContext
{
    public Dsw2025TpiContext(DbContextOptions<Dsw2025TpiContext> options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Orden> Ordenes { get; set; }
    public DbSet<DetalleOrden> DetallesOrden { get; set; }
}

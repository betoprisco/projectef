using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext : DbContext
{
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
}
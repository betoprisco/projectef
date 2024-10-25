using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext : DbContext
{
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit =
        [
            new Categoria 
            { 
                CategoriaId = Guid.Parse("28b26fa3-8035-469b-8d6f-603a6130b578"), 
                Nombre = "Actividades Pendientes", 
                Peso = 20 
            },
            new Categoria 
            { 
                CategoriaId = Guid.Parse("28b26fa3-8035-469b-8d6f-603a6130b579"), 
                Nombre = "Actividades Personales", 
                Peso = 50 
            },
            new Categoria 
            { 
                CategoriaId = Guid.Parse("28b26fa3-8035-469b-8d6f-603a6130b580"), 
                Nombre = "Actividades Laborales", 
                Peso = 30 
            },
            new Categoria 
            { 
                CategoriaId = Guid.Parse("28b26fa3-8035-469b-8d6f-603a6130b581"), 
                Nombre = "Actividades de Estudio", 
                Peso = 40 
            },
        ];
        
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.CategoriaId);
            categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(c => c.Descripcion).IsRequired(false).HasMaxLength(500);
            categoria.Property(c => c.Peso).HasDefaultValue(1);

            categoria.HasData(categoriasInit);
            
        });

        List<Tarea> tareasInit =
        [
            new Tarea 
            { 
                TareaId = Guid.Parse("3843931d-0caa-4c85-b866-cf943b645bab"), 
                CategoriaId = Guid.Parse("28b26fa3-8035-469b-8d6f-603a6130b578"),
                Titulo = "Pago de servicios públicos", 
                FechaCreacion = DateTime.Now,
                PrioridadTarea = Prioridad.Media
            },
            new Tarea 
            { 
                TareaId = Guid.Parse("3843931d-0caa-4c85-b866-cf943b645bac"), 
                CategoriaId = Guid.Parse("28b26fa3-8035-469b-8d6f-603a6130b579"),
                Titulo = "Terminar de ver película en Apple TV+", 
                FechaCreacion = DateTime.Now,
                PrioridadTarea = Prioridad.Baja
            },
            new Tarea 
            { 
                TareaId = Guid.Parse("3843931d-0caa-4c85-b866-cf943b645bad"), 
                CategoriaId = Guid.Parse("28b26fa3-8035-469b-8d6f-603a6130b580"),
                Titulo = "Revisar correos electrónicos", 
                FechaCreacion = DateTime.Now,
                PrioridadTarea = Prioridad.Alta
            },
            new Tarea 
            { 
                TareaId = Guid.Parse("3843931d-0caa-4c85-b866-cf943b645bae"), 
                CategoriaId = Guid.Parse("28b26fa3-8035-469b-8d6f-603a6130b581"),
                Titulo = "Estudiar para el examen de matemáticas", 
                FechaCreacion = DateTime.Now,
                PrioridadTarea = Prioridad.Media
            }
        ];

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareaId);
            tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion).IsRequired(false);
            tarea.Property(t => t.PrioridadTarea).HasConversion<string>();
            tarea.Property(t => t.FechaCreacion).HasDefaultValueSql("GETDATE()");
            tarea.Ignore(t => t.Resumen);

            tarea.HasData(tareasInit);
        });
    }
}
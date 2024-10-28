using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
using proyectoef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDB"));

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("dbConexion", async ([FromServices] TareasContext db) =>
{
    await db.Database.EnsureCreatedAsync();
    return Results.Ok("Base de datos en memoria: " + db.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    var tareas = await dbContext.Tareas.ToListAsync();
    return Results.Ok(tareas);
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext,[FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;

    await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext,[FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    //Busca por la llave primaria
    var tareaActual = await dbContext.Tareas.FindAsync(id);

    if (tareaActual == null)
    {
        return Results.NotFound();
    }

    tareaActual.CategoriaId = tarea.CategoriaId;
    tareaActual.Titulo = tarea.Titulo;
    tareaActual.Descripcion = tarea.Descripcion;
    tareaActual.PrioridadTarea = tarea.PrioridadTarea;

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    //Busca por la llave primaria
    var tareaActual = await dbContext.Tareas.FindAsync(id);

    if (tareaActual == null)
    {
        return Results.NotFound();
    }

    dbContext.Tareas.Remove(tareaActual);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();

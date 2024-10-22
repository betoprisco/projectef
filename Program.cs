using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

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

app.Run();

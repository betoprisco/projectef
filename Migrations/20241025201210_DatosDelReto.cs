using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class DatosDelReto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("28b26fa3-8035-469b-8d6f-603a6130b580"), null, "Actividades Laborales", 30 },
                    { new Guid("28b26fa3-8035-469b-8d6f-603a6130b581"), null, "Actividades de Estudio", 40 }
                });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3843931d-0caa-4c85-b866-cf943b645bab"),
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 25, 15, 12, 10, 318, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3843931d-0caa-4c85-b866-cf943b645bac"),
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 25, 15, 12, 10, 319, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("3843931d-0caa-4c85-b866-cf943b645bad"), new Guid("28b26fa3-8035-469b-8d6f-603a6130b580"), null, new DateTime(2024, 10, 25, 15, 12, 10, 319, DateTimeKind.Local).AddTicks(7063), "Alta", "Revisar correos electrónicos" },
                    { new Guid("3843931d-0caa-4c85-b866-cf943b645bae"), new Guid("28b26fa3-8035-469b-8d6f-603a6130b581"), null, new DateTime(2024, 10, 25, 15, 12, 10, 319, DateTimeKind.Local).AddTicks(7066), "Media", "Estudiar para el examen de matemáticas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3843931d-0caa-4c85-b866-cf943b645bad"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3843931d-0caa-4c85-b866-cf943b645bae"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("28b26fa3-8035-469b-8d6f-603a6130b580"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("28b26fa3-8035-469b-8d6f-603a6130b581"));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3843931d-0caa-4c85-b866-cf943b645bab"),
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 25, 14, 53, 41, 955, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3843931d-0caa-4c85-b866-cf943b645bac"),
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 25, 14, 53, 41, 956, DateTimeKind.Local).AddTicks(7279));
        }
    }
}

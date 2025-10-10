using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCalificacionEstudiante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreFieldsToMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoMateria",
                table: "Materias",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Creditos",
                table: "Materias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfesorAsignado",
                table: "Materias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoMateria",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Creditos",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "ProfesorAsignado",
                table: "Materias");
        }
    }
}

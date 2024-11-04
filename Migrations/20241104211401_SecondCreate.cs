using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSoft.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Usuario",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Usuario",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Usuario",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Usuario");
        }
    }
}

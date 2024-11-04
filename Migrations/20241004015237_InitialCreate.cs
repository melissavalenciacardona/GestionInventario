using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSoft.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Calle = table.Column<string>(type: "longtext", nullable: false),
                    Numero = table.Column<string>(type: "longtext", nullable: false),
                    Ciudad = table.Column<string>(type: "longtext", nullable: false),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: false),
                    Pais = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Preferencia",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    RecibirInformacion = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NotificacionPorSms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CanalPreferido = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferencia", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Telefono = table.Column<string>(type: "longtext", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false),
                    DireccionId = table.Column<string>(type: "varchar(255)", nullable: false),
                    PreferenciaId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_Preferencia_PreferenciaId",
                        column: x => x.PreferenciaId,
                        principalTable: "Preferencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_DireccionId",
                table: "Cliente",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PreferenciaId",
                table: "Cliente",
                column: "PreferenciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Preferencia");
        }
    }
}

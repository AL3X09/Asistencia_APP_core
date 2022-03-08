using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asistencia_rips_APP.Data.Migrations
{
    public partial class Agregar_clases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipoasistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipoasistencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subdireccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionId = table.Column<int>(type: "int", nullable: false),
                    is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdireccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subdireccion_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formasistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consec = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombres_contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos_contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datos_contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compromisos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemaId = table.Column<int>(type: "int", nullable: false),
                    TipoAsistenciaId = table.Column<int>(type: "int", nullable: false),
                    is_Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formasistencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formasistencia_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Formasistencia_Tema_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Tema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Formasistencia_Tipoasistencia_TipoAsistenciaId",
                        column: x => x.TipoAsistenciaId,
                        principalTable: "Tipoasistencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSubdireccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubdireccionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubdireccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSubdireccion_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSubdireccion_Subdireccion_SubdireccionId",
                        column: x => x.SubdireccionId,
                        principalTable: "Subdireccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Formasistencia_TemaId",
                table: "Formasistencia",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Formasistencia_TipoAsistenciaId",
                table: "Formasistencia",
                column: "TipoAsistenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Formasistencia_UserId",
                table: "Formasistencia",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subdireccion_DireccionId",
                table: "Subdireccion",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubdireccion_SubdireccionId",
                table: "UserSubdireccion",
                column: "SubdireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubdireccion_UserId",
                table: "UserSubdireccion",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formasistencia");

            migrationBuilder.DropTable(
                name: "UserSubdireccion");

            migrationBuilder.DropTable(
                name: "Tema");

            migrationBuilder.DropTable(
                name: "Tipoasistencia");

            migrationBuilder.DropTable(
                name: "Subdireccion");

            migrationBuilder.DropTable(
                name: "Direccion");
        }
    }
}

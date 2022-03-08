using Microsoft.EntityFrameworkCore.Migrations;

namespace asistencia_rips_APP.Data.Migrations
{
    public partial class Update_TblAsistencia_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoTramiteId",
                table: "Formasistencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Formasistencia_EstadoTramiteId",
                table: "Formasistencia",
                column: "EstadoTramiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formasistencia_EstadoTramite_EstadoTramiteId",
                table: "Formasistencia",
                column: "EstadoTramiteId",
                principalTable: "EstadoTramite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formasistencia_EstadoTramite_EstadoTramiteId",
                table: "Formasistencia");

            migrationBuilder.DropIndex(
                name: "IX_Formasistencia_EstadoTramiteId",
                table: "Formasistencia");

            migrationBuilder.DropColumn(
                name: "EstadoTramiteId",
                table: "Formasistencia");
        }
    }
}

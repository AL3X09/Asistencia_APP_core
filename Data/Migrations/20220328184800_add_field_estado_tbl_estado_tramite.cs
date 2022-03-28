using Microsoft.EntityFrameworkCore.Migrations;

namespace asistencia_rips_APP.Data.Migrations
{
    public partial class add_field_estado_tbl_estado_tramite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_Active",
                table: "EstadoTramite",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_Active",
                table: "EstadoTramite");
        }
    }
}

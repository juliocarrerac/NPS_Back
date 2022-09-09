using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa.Aplicacion.Infraestructura.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    Calificacion_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    Clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor_Calificacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificacion", x => x.Calificacion_Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Perfil_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Perfil_Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Usuario_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usuario_Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_Perfil_Id",
                        column: x => x.Perfil_Id,
                        principalTable: "Perfil",
                        principalColumn: "Perfil_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Calificacion",
                columns: new[] { "Calificacion_Id", "Clasificacion", "Usuario_Id", "Valor_Calificacion" },
                values: new object[,]
                {
                    { 1, "", 2, null },
                    { 2, "", 3, null },
                    { 3, "", 4, null },
                    { 4, "", 5, null },
                    { 5, "", 6, null }
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Perfil_Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Votante" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Usuario_Id", "Apellidos", "Login", "Nombres", "Password", "Perfil_Id" },
                values: new object[,]
                {
                    { 1, "Admin", "admin", "Admin", "123456", 1 },
                    { 2, "Usuario 1", "Usuario1", "Usuario 1", "123456", 2 },
                    { 3, "Usuario 2", "Usuario2", "Usuario 2", "123456", 2 },
                    { 4, "Usuario 3", "Usuario3", "Usuario 3", "123456", 2 },
                    { 5, "Usuario 4", "Usuario4", "Usuario 4", "123456", 2 },
                    { 6, "Usuario 5", "Usuario5", "Usuario 5", "123456", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_Calificacion_Id",
                table: "Calificacion",
                column: "Calificacion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_Perfil_Id",
                table: "Perfil",
                column: "Perfil_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Perfil_Id",
                table: "Usuario",
                column: "Perfil_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Usuario_Id",
                table: "Usuario",
                column: "Usuario_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}

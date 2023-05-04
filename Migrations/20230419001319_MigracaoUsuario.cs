using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Personagens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "fotoPersonagem",
                table: "Personagens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Personagens",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Armas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "fotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "fotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "fotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "fotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "fotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "fotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "fotoPersonagem", "usuarioId" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 244, 241, 131, 6, 228, 11, 161, 218, 157, 102, 1, 229, 234, 253, 136, 50, 235, 189, 17, 190, 106, 130, 139, 103, 119, 100, 167, 180, 64, 207, 126, 96, 228, 14, 56, 198, 27, 206, 204, 222, 219, 80, 54, 213, 12, 147, 87, 229, 138, 44, 29, 156, 42, 241, 10, 115, 207, 62, 152, 172, 86, 48, 203, 229 }, new byte[] { 6, 159, 141, 97, 43, 19, 106, 53, 237, 15, 131, 254, 3, 28, 83, 35, 115, 191, 84, 223, 3, 7, 160, 90, 105, 210, 148, 198, 198, 209, 118, 135, 150, 98, 87, 197, 148, 185, 39, 58, 78, 27, 239, 113, 241, 7, 151, 118, 31, 0, 30, 245, 13, 159, 168, 175, 199, 108, 114, 109, 225, 239, 113, 120, 18, 207, 109, 128, 7, 187, 39, 135, 15, 157, 233, 142, 133, 215, 250, 185, 246, 132, 184, 104, 125, 193, 61, 0, 8, 187, 77, 2, 127, 92, 113, 205, 202, 61, 248, 205, 5, 98, 8, 40, 29, 117, 245, 61, 192, 251, 85, 2, 65, 151, 167, 238, 222, 245, 65, 65, 129, 107, 239, 31, 140, 210, 76, 133 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_usuarioId",
                table: "Personagens",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_usuarioId",
                table: "Personagens",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_usuarioId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_usuarioId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "fotoPersonagem",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Personagens");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Personagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Armas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

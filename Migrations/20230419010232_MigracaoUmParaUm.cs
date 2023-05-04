using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_usuarioId",
                table: "Personagens");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Personagens",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Personagens_usuarioId",
                table: "Personagens",
                newName: "IX_Personagens_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 35, 96, 215, 37, 197, 213, 81, 232, 131, 200, 125, 106, 215, 208, 21, 249, 172, 175, 129, 119, 90, 200, 111, 135, 126, 175, 82, 176, 190, 135, 137, 79, 143, 141, 75, 16, 161, 240, 52, 115, 169, 31, 57, 56, 86, 36, 214, 63, 228, 115, 177, 137, 230, 137, 155, 123, 194, 230, 195, 201, 115, 37, 108, 164 }, new byte[] { 121, 49, 39, 139, 10, 136, 21, 95, 93, 27, 102, 238, 43, 111, 120, 111, 123, 189, 228, 220, 231, 215, 157, 39, 163, 24, 95, 223, 82, 12, 72, 95, 153, 93, 143, 168, 11, 240, 244, 220, 73, 83, 184, 227, 132, 245, 55, 18, 219, 79, 36, 226, 127, 99, 89, 170, 74, 74, 174, 244, 143, 151, 205, 199, 20, 215, 132, 115, 216, 217, 19, 6, 72, 235, 50, 46, 239, 191, 35, 69, 209, 113, 127, 236, 208, 2, 43, 1, 245, 72, 137, 98, 144, 102, 140, 121, 116, 53, 122, 138, 164, 174, 193, 228, 95, 203, 248, 2, 26, 183, 119, 58, 172, 67, 206, 242, 69, 22, 69, 53, 209, 130, 181, 134, 24, 223, 74, 177 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Personagens",
                newName: "usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                newName: "IX_Personagens_usuarioId");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 244, 241, 131, 6, 228, 11, 161, 218, 157, 102, 1, 229, 234, 253, 136, 50, 235, 189, 17, 190, 106, 130, 139, 103, 119, 100, 167, 180, 64, 207, 126, 96, 228, 14, 56, 198, 27, 206, 204, 222, 219, 80, 54, 213, 12, 147, 87, 229, 138, 44, 29, 156, 42, 241, 10, 115, 207, 62, 152, 172, 86, 48, 203, 229 }, new byte[] { 6, 159, 141, 97, 43, 19, 106, 53, 237, 15, 131, 254, 3, 28, 83, 35, 115, 191, 84, 223, 3, 7, 160, 90, 105, 210, 148, 198, 198, 209, 118, 135, 150, 98, 87, 197, 148, 185, 39, 58, 78, 27, 239, 113, 241, 7, 151, 118, 31, 0, 30, 245, 13, 159, 168, 175, 199, 108, 114, 109, 225, 239, 113, 120, 18, 207, 109, 128, 7, 187, 39, 135, 15, 157, 233, 142, 133, 215, 250, 185, 246, 132, 184, 104, 125, 193, 61, 0, 8, 187, 77, 2, 127, 92, 113, 205, 202, 61, 248, 205, 5, 98, 8, 40, 29, 117, 245, 61, 192, 251, 85, 2, 65, 151, 167, 238, 222, 245, 65, 65, 129, 107, 239, 31, 140, 210, 76, 133 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_usuarioId",
                table: "Personagens",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}

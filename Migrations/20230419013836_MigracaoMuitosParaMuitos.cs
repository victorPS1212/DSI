using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 186, 187, 57, 194, 157, 204, 51, 245, 92, 56, 1, 134, 134, 8, 160, 143, 150, 27, 164, 15, 200, 137, 59, 167, 3, 207, 205, 86, 186, 107, 112, 210, 248, 150, 182, 152, 57, 196, 245, 175, 50, 211, 189, 63, 45, 188, 22, 223, 49, 222, 68, 43, 87, 150, 249, 232, 190, 153, 52, 157, 30, 202, 5, 29 }, new byte[] { 157, 48, 0, 63, 110, 42, 78, 117, 93, 71, 123, 66, 119, 2, 48, 114, 110, 83, 161, 114, 232, 111, 105, 171, 101, 71, 135, 239, 24, 151, 224, 238, 51, 154, 116, 179, 118, 101, 20, 147, 208, 164, 218, 76, 36, 167, 68, 203, 248, 133, 253, 135, 23, 95, 220, 195, 185, 152, 175, 180, 33, 45, 229, 96, 92, 202, 125, 163, 163, 221, 15, 37, 181, 40, 56, 123, 78, 137, 59, 146, 135, 245, 238, 225, 127, 244, 167, 154, 112, 238, 74, 205, 125, 143, 130, 249, 106, 215, 58, 77, 26, 63, 90, 173, 143, 75, 183, 71, 91, 205, 200, 10, 156, 99, 194, 142, 72, 250, 241, 102, 189, 38, 105, 222, 171, 12, 242, 24 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 35, 96, 215, 37, 197, 213, 81, 232, 131, 200, 125, 106, 215, 208, 21, 249, 172, 175, 129, 119, 90, 200, 111, 135, 126, 175, 82, 176, 190, 135, 137, 79, 143, 141, 75, 16, 161, 240, 52, 115, 169, 31, 57, 56, 86, 36, 214, 63, 228, 115, 177, 137, 230, 137, 155, 123, 194, 230, 195, 201, 115, 37, 108, 164 }, new byte[] { 121, 49, 39, 139, 10, 136, 21, 95, 93, 27, 102, 238, 43, 111, 120, 111, 123, 189, 228, 220, 231, 215, 157, 39, 163, 24, 95, 223, 82, 12, 72, 95, 153, 93, 143, 168, 11, 240, 244, 220, 73, 83, 184, 227, 132, 245, 55, 18, 219, 79, 36, 226, 127, 99, 89, 170, 74, 74, 174, 244, 143, 151, 205, 199, 20, 215, 132, 115, 216, 217, 19, 6, 72, 235, 50, 46, 239, 191, 35, 69, 209, 113, 127, 236, 208, 2, 43, 1, 245, 72, 137, 98, 144, 102, 140, 121, 116, 53, 122, 138, 164, 174, 193, 228, 95, 203, 248, 2, 26, 183, 119, 58, 172, 67, 206, 242, 69, 22, 69, 53, 209, 130, 181, 134, 24, 223, 74, 177 } });
        }
    }
}

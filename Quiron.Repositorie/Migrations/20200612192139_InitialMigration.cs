using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiron.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Espaco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espaco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Uf = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Espaco",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("2104499d-ed03-4a2a-9995-c21c6c23ceaa"), "Salão de Festas" },
                    { new Guid("872a4818-ab40-4950-a297-9ea81983495f"), "Piscina" },
                    { new Guid("9a4ae6c2-0e91-459e-9d2b-fb755c952195"), "Churrasqueira" }
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Descricao", "Uf" },
                values: new object[,]
                {
                    { new Guid("24f63b78-c0da-4f6c-a817-14844384edc4"), "Ceara", "CE" },
                    { new Guid("970bfe8c-5050-4a43-bc9a-ed0a38098691"), "Sao Paulo", "SP" },
                    { new Guid("fa50ba2f-b9c8-4092-bf0f-588cca61463c"), "Rio de Janeiro", "RJ" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Espaco");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}

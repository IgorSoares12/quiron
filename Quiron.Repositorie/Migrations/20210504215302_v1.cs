using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiron.Data.Migrations
{
    public partial class v1 : Migration
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
                    { new Guid("699009e2-050a-43ed-bf00-8b383933b2d5"), "Salão de Festas" },
                    { new Guid("4e58e765-95ff-4815-8968-3c5199053b20"), "Piscina" },
                    { new Guid("bb12a32a-97f2-451e-8bbd-84ee3abbb39a"), "Churrasqueira" }
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Descricao", "Uf" },
                values: new object[,]
                {
                    { new Guid("578c1771-e576-47e7-9c0e-7b84e250758d"), "Ceara", "CE" },
                    { new Guid("08e9b674-c360-4980-b52e-4ff7f5cc722c"), "Sao Paulo", "SP" },
                    { new Guid("262e36b2-2951-48e3-9ccc-5c3e06d846b9"), "Rio de Janeiro", "RJ" }
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

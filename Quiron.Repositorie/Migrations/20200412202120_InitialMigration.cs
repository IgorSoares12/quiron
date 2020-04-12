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
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espaco", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Espaco",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { new Guid("2c221e33-bcb0-46ab-89df-2c53577dc70b"), "Salão de Festas" },
                    { new Guid("442e9257-aa8f-4790-b8d5-ef74038ec504"), "Piscina" },
                    { new Guid("9cb1e11d-9bb4-4abb-babd-4439a8da3751"), "Churrasqueira" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Espaco");
        }
    }
}

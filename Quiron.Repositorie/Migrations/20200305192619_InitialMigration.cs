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
                values: new object[] { new Guid("a1dad22f-7745-445a-bd37-ab1b5bf6f993"), "Salão de Festas" });

            migrationBuilder.InsertData(
                table: "Espaco",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("efdd12fe-6a7f-482f-af2f-c2395188bcc7"), "Piscina" });

            migrationBuilder.InsertData(
                table: "Espaco",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { new Guid("c1d514db-6c2b-47eb-bbe2-b6a3cc3ec25b"), "Churrasqueira" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Espaco");
        }
    }
}

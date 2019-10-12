using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pets.Core.Migrations
{
    public partial class banhoPetAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    PetId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banhos_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banhos_PetId",
                table: "Banhos",
                column: "PetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banhos");
        }
    }
}

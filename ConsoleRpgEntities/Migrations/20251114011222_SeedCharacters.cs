using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpgEntities.Migrations
{
    public partial class SeedCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Players_EquipmentId",
                table: "Players",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Equipments_EquipmentId",
                table: "Players",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Equipments_EquipmentId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_EquipmentId",
                table: "Players");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Core3Shop.Dal.Migrations
{
    public partial class FixServiceDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Frequencies_CategoryId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImgeUrl",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_FrequencyId",
                table: "Services",
                column: "FrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Frequencies_FrequencyId",
                table: "Services",
                column: "FrequencyId",
                principalTable: "Frequencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Frequencies_FrequencyId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_FrequencyId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Services");

            migrationBuilder.AddColumn<double>(
                name: "ImgeUrl",
                table: "Services",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Frequencies_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "Frequencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

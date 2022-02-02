using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class NotInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "toys",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_toys_OwnerId",
                table: "toys",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_toys_children_OwnerId",
                table: "toys",
                column: "OwnerId",
                principalTable: "children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toys_children_OwnerId",
                table: "toys");

            migrationBuilder.DropIndex(
                name: "IX_toys_OwnerId",
                table: "toys");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "toys");
        }
    }
}

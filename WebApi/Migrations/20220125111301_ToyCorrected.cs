using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class ToyCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toys_children_OwnerIdId",
                table: "toys");

            migrationBuilder.DropIndex(
                name: "IX_toys_OwnerIdId",
                table: "toys");

            migrationBuilder.DropColumn(
                name: "OwnerIdId",
                table: "toys");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "toys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "toys");

            migrationBuilder.AddColumn<int>(
                name: "OwnerIdId",
                table: "toys",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_toys_OwnerIdId",
                table: "toys",
                column: "OwnerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_toys_children_OwnerIdId",
                table: "toys",
                column: "OwnerIdId",
                principalTable: "children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

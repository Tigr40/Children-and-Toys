using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class ToyUpdateCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toys_children_OwnerId",
                table: "toys");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "toys",
                newName: "OwnerIdId");

            migrationBuilder.RenameIndex(
                name: "IX_toys_OwnerId",
                table: "toys",
                newName: "IX_toys_OwnerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_toys_children_OwnerIdId",
                table: "toys",
                column: "OwnerIdId",
                principalTable: "children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_toys_children_OwnerIdId",
                table: "toys");

            migrationBuilder.RenameColumn(
                name: "OwnerIdId",
                table: "toys",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_toys_OwnerIdId",
                table: "toys",
                newName: "IX_toys_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_toys_children_OwnerId",
                table: "toys",
                column: "OwnerId",
                principalTable: "children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

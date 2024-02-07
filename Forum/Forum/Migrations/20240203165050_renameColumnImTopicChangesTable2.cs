using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Migrations
{
    /// <inheritdoc />
    public partial class renameColumnImTopicChangesTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_CreateUserId",
                table: "TopicsChanges");

            migrationBuilder.DropIndex(
                name: "IX_TopicsChanges_CreateUserId",
                table: "TopicsChanges");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "TopicsChanges");

            migrationBuilder.AlterColumn<string>(
                name: "ChangeUserId",
                table: "TopicsChanges",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TopicsChanges_ChangeUserId",
                table: "TopicsChanges",
                column: "ChangeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_ChangeUserId",
                table: "TopicsChanges",
                column: "ChangeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_ChangeUserId",
                table: "TopicsChanges");

            migrationBuilder.DropIndex(
                name: "IX_TopicsChanges_ChangeUserId",
                table: "TopicsChanges");

            migrationBuilder.AlterColumn<string>(
                name: "ChangeUserId",
                table: "TopicsChanges",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "TopicsChanges",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TopicsChanges_CreateUserId",
                table: "TopicsChanges",
                column: "CreateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_CreateUserId",
                table: "TopicsChanges",
                column: "CreateUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

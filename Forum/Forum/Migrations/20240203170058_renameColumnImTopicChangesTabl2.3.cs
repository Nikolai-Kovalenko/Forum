using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Migrations
{
    /// <inheritdoc />
    public partial class renameColumnImTopicChangesTabl23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_ChangeUserId",
                table: "TopicsChanges");

            migrationBuilder.AlterColumn<string>(
                name: "ChangeUserId",
                table: "TopicsChanges",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_ChangeUserId",
                table: "TopicsChanges",
                column: "ChangeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_ChangeUserId",
                table: "TopicsChanges");

            migrationBuilder.AlterColumn<string>(
                name: "ChangeUserId",
                table: "TopicsChanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicsChanges_AspNetUsers_ChangeUserId",
                table: "TopicsChanges",
                column: "ChangeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
